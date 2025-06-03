using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OneOf;
using OneOf.Types;
using SOH.CORE.Dto;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Customer;
using SOH.MAIN.Models.Users;
using SOH.PERSISTENCE.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SOH.PERSISTENCE.Repository
{
    internal class UserRepository : IUserRepository
    {
        // Injección de dependencias
        private readonly UserManager<SR_Users> _usersManager;
        private readonly IConfiguration _configuration;
        private readonly AplicationDbContext _dbContext;
        public UserRepository(UserManager<SR_Users> userManager, IConfiguration configuration,
         AplicationDbContext context)
        {
            _usersManager = userManager;
            _configuration = configuration;
            _dbContext = context;
        }

        //Implementación de interfaz para agregar un nuevo usuario
        public async Task<OneOf<SR_Users, string>> AddUserAsync(string roleName, SR_Users user)
        {
            user.UserName = user.Email;
            var result = await _usersManager.CreateAsync(user, user.PasswordHash);
            if (!result.Succeeded) return "null";

            var asignation = await _usersManager.AddToRoleAsync(user, roleName);

            return asignation.Succeeded ? user : null;
        }

        //Implementación de interfaz para llamar a todos los usuarios
        public async Task<List<SR_Users>> GetAllUserAsync()
        {
            var result = await _usersManager.Users.ToListAsync();
            if (result.Count > 0) return result;

            return null;
        }

        //Implementación de interfaz para llamar un usuario por ID
        public async Task<SR_Users> GetUserAsync(string id)
        {

            var result = await _usersManager.FindByIdAsync(id);
            return result;
        }

        // Obtener rol de usuario
        public async Task<IList<string>> GetUserRolesAsync(SR_Users user)
        {
            return await _usersManager.GetRolesAsync(user);
        }


        public async Task<SR_Users> GetUserByEmailAsync(string email)
        {
            var result = await _usersManager.FindByEmailAsync(email);

            if (result != null)
            {
                _dbContext.Entry(result).State = EntityState.Detached;
            } 

            return result;
        }

        public async Task<bool> UpdatePasswordAsync(SR_Users user)
        {
            var usuarioExistente = await _usersManager.FindByIdAsync(user.Id);
            if (usuarioExistente == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            var resetToken = await _usersManager.GeneratePasswordResetTokenAsync(usuarioExistente);
            var result = await _usersManager.ResetPasswordAsync(usuarioExistente, resetToken, user.PasswordHash);

            //Guardar la fecha de cambio
            usuarioExistente.dateModify = user.dateModify;
            var result2 = await _usersManager.UpdateAsync(usuarioExistente);
            if (result.Succeeded && result2.Succeeded) return true;

            return false;
        }

        //Implementación de interfaz para actualiar un usuario
        public async Task<SR_Users> UpdateUserAsync(SR_Users user)
        {
            // Validar si el usuario existe
            var existente = await _usersManager.FindByIdAsync(user.Id);
            if (existente == null) return null;

            existente.Email = user.Email;
            existente.UserName = user.Email;
            existente.dateModify = user.dateModify;
            existente.PhoneNumber = user.PhoneNumber;

            try
            {
                var result = await _usersManager.UpdateAsync(existente);
                return result.Succeeded ? existente : null;
            }
            catch (DbUpdateConcurrencyException)
{
                return null;
            }
        }

        //Implementación de interfaz para actualiar un usuario
        public async Task<bool> IsActivoUserAsync(string id,  bool value)
        {

            var usuarioExistente = await _usersManager.FindByIdAsync(id);
            if (usuarioExistente == null) return false;

            usuarioExistente.isActive = value;
            usuarioExistente.dateModify = DateTime.Now.ToLocalTime();

            var result = await _usersManager.UpdateAsync(usuarioExistente);
            if (result.Succeeded) return true;

            return false;
        }

        public async Task<ValidarUser> ValidarUserAsync(string email, string password)
        {
            // Instanciar el Dto.
            ValidarUser validar = new();

            // Validar si el correo existe.
            var user = await _usersManager.FindByEmailAsync(email);
            if (user == null)
            {
                validar.respuesta = "El email no fue encontrado";
                return validar;
            }

            // Validar si la contraseña es correcta
            if (!await _usersManager.CheckPasswordAsync(user, password))
            {
                validar.respuesta = "La contraseña es incorrecta";
                return validar;
            }

            // Validar si el usuario esta activo
            if (!user.isActive)
            {
                validar.respuesta = "Usuario inactivo";
                return validar;
            }

            // Obtener el tipo de persona que esta iniciando sesión
            var person = await _dbContext.SRH_Person.FirstOrDefaultAsync(x => x.idPerson == user.idPerson);

            // Obtener el rol del usuario.
            var rol = await _usersManager.GetRolesAsync(user);

            // Autentication: 
            var authClaims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            // Llenar datos de retorno
            validar.Id = user.Id;
            validar.idPerson = user.idPerson;
            validar.Rol = rol;
            validar.respuesta = "OK";
            validar.idTypePerson = person.idTypePerson;
            validar.token = (new JwtSecurityTokenHandler().WriteToken(token));


            // Llenar datos
            return validar;
        }
    }
}
