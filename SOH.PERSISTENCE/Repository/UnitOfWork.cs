using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Booking;
using SOH.MAIN.Models.Customer;
using SOH.MAIN.Models.Employee;
using SOH.MAIN.Models.Payments;
using SOH.MAIN.Models.Users;
using SOH.PERSISTENCE.Data;

namespace SOH.PERSISTENCE.Repository
{
    internal class UnitOfWork : IUnitOfWork
    {
        // Definir Variable de lectura
        private readonly AplicationDbContext _dbContext;
        
        // Definir Implementación de la interfaz
        public IRepository<SR_Users> User { get; }

        public IRepository<SR_Employee> UEmployee { get; }

        public IRepository<SR_TypeEmployee> UTypeEmployee { get; }

        public IRepository<SR_Person> UPerson { get; }

        public IRepository<SR_TypePerson> UTypePerson { get; }

        public IRepository<SR_City> UCity { get; }

        public IRepository<SR_Country> UCountry { get; }

        public IRepository<SR_Contacts> UContacts { get; }

        public IRepository<SR_Booking> UBooking { get; }

        public IRepository<SR_Calendar> UCalendar { get; }

        public IRepository<SR_CalendarDetail> UCalendarDetail { get; }

        public IRepository<SR_RoomDetail> URoomDetail { get; }

        public IRepository<SR_Room> URoom { get; }

        public IRepository<SR_Binnacle> UBinnacle { get; }

        public IRepository<SR_Promotion> UPromotion { get; }

        public IRepository<SR_CategoryRoom> UCategoryRoom { get; }

        public IRepository<SR_Bill> UBill { get; }

        public IRepository<SR_TypePay> UTypePay { get; }

        public IRepository<SR_Recharge> URecharge { get; }

        // Inyección de dependencias
        public UnitOfWork(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            //Employee
            UEmployee = new Repository<SR_Employee>(dbContext);
            UTypeEmployee = new Repository<SR_TypeEmployee>(dbContext);

            //Customer
            UPerson = new Repository<SR_Person>(dbContext);
            UTypePerson = new Repository<SR_TypePerson>(dbContext);
            UCity = new Repository<SR_City>(dbContext);
            UCountry = new Repository<SR_Country>(dbContext);
            UContacts = new Repository<SR_Contacts>(dbContext);

            //Booking
            UBooking = new Repository<SR_Booking>(dbContext);
            UCalendar = new Repository<SR_Calendar>(dbContext);
            UCalendarDetail = new Repository<SR_CalendarDetail>(dbContext);
            URoom = new Repository<SR_Room>(dbContext);
            URoomDetail = new Repository<SR_RoomDetail>(dbContext);
            UCategoryRoom = new Repository<SR_CategoryRoom>(dbContext);
            UPromotion = new Repository<SR_Promotion>(dbContext);
            UBinnacle = new Repository<SR_Binnacle>(dbContext);

            //Payments
            UBill = new Repository<SR_Bill>(dbContext);
            UTypePay = new Repository<SR_TypePay>(dbContext);
            URecharge = new Repository<SR_Recharge>(dbContext);
        }

        public async Task SaveChanges()
        {
            _dbContext.SaveChangesAsync();
        }
    }
}
