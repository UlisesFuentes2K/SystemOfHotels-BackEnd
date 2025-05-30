using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Users;
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
        public UserRepository(UserManager<SR_Users> userManager, IConfiguration configuration)
        {
            _usersManager = userManager;
            _configuration = configuration;
        }

        //Implementación de interfaz para agregar un nuevo usuario
        public async Task<SR_Users> AddUserAsync(string roleName, SR_Users user)
        {
            user.UserName = user.Email;
            var result =  await _usersManager.CreateAsync(user, user.PasswordHash);
            if (!result.Succeeded) return null;

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
            return await _usersManager.FindByIdAsync(id);
        }

        public async Task<SR_Users> GetUserByEmailAsync(string email)
        {
            return await _usersManager.FindByEmailAsync(email);
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

            var usuarioExistente = await _usersManager.FindByIdAsync(user.Id);
            if (usuarioExistente == null) return null;

            usuarioExistente.Email = user.Email;
            usuarioExistente.UserName = user.Email;
            usuarioExistente.dateModify = user.dateModify;

            var result = await _usersManager.UpdateAsync(usuarioExistente);
            if (result.Succeeded) return usuarioExistente;

            return null;
        }

        //Implementación de interfaz para actualiar un usuario
        public async Task<bool> IsActivoUserAsync(SR_Users user)
        {

            var usuarioExistente = await _usersManager.FindByIdAsync(user.Id);
            if (usuarioExistente == null) return false;

            usuarioExistente.isActive = user.isActive;
            usuarioExistente.dateModify = user.dateModify;

            var result = await _usersManager.UpdateAsync(usuarioExistente);
            if (result.Succeeded) return true;

            return false;
        }

        public async Task<(string token, string userId)> ValidarUserAsync(string email, string password)
        {
            var user = await _usersManager.FindByEmailAsync(email);
            if(user != null && await _usersManager.CheckPasswordAsync(user, password))
            {
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

                return (new JwtSecurityTokenHandler().WriteToken(token), user.Id);
            }

            return (null, null);
        }
    }
}
