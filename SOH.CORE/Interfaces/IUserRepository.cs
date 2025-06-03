using OneOf;
using SOH.CORE.Dto;
using SOH.MAIN.Models.Users;

namespace SOH.CORE.Interfaces
{
    public interface IUserRepository
    {
        // Llamar todos los usuarios
        Task<List<SR_Users>> GetAllUserAsync();

        //Llamar usuario por ID
        Task<SR_Users> GetUserAsync(string id);

        //Llamar el rol del usuario
        Task<IList<string>> GetUserRolesAsync(SR_Users user);

        //Llamar usuario por Email
        Task<SR_Users> GetUserByEmailAsync(string email);

        // Guardar nuevo usuario
        Task<OneOf<SR_Users, string>> AddUserAsync(string roleName, SR_Users user);

        //Actualizar usuario
        Task<SR_Users> UpdateUserAsync(SR_Users user);

        // Actualizar contraseña
        Task<bool> UpdatePasswordAsync(SR_Users user);

        // Desactivar cliente
        Task<bool> IsActivoUserAsync(string id, bool value);

        //Actualizar usuario
        Task<ValidarUser> ValidarUserAsync(string email, string password);
    }
}
