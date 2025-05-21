using SOH.MAIN.Models.Users;

namespace SOH.CORE.Interfaces
{
    public interface IUserRepository
    {
        // Llamar todos los usuarios
        Task<List<SR_Users>> GetAllUserAsync();

        //Llamar usuario por ID
        Task<SR_Users> GetUserAsync(string id);

        // Guardar nuevo usuario
        Task<SR_Users> AddUserAsync(SR_Users user);

        //Actualizar usuario
        Task<SR_Users> UpdateUserAsync(SR_Users user);

        //Actualizar usuario
        Task<(string token, string userId)> ValidarUserAsync(string email, string password);
    }
}
