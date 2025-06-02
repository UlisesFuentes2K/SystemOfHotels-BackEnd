using SOH.MAIN.Models.Booking;
using SOH.MAIN.Models.Customer;
using SOH.MAIN.Models.Employee;
using SOH.MAIN.Models.Payments;
using SOH.MAIN.Models.Users;

namespace SOH.CORE.Interfaces
{
    public interface IUnitOfWork
    {
        //Users
        public IUserRepository IUser { get; }

        //Employee
        public IRepository<SR_Employee> UEmployee { get;}
        public IRepository<SR_TypeEmployee> UTypeEmployee { get;}

        //Customer
        public IRepository<SR_Person> UPerson { get; }
        public IRepository<SR_TypePerson> UTypePerson { get; }
        public IRepository<SR_City> UCity { get; }
        public IRepository<SR_Country> UCountry { get; }
        public IRepository<SR_Contacts> UContacts { get; }

        //Booking
        public IRepository<SR_Booking> UBooking { get; }
        public IRepository<SR_Calendar> UCalendar { get; }
        public IRepository<SR_CalendarDetail> UCalendarDetail { get; }
        public IRepository<SR_RoomDetail> URoomDetail { get; }
        public IRepository<SR_Room> URoom { get; }
        public IRepository<SR_Binnacle> UBinnacle { get; }
        public IRepository<SR_Promotion> UPromotion { get; }
        public IRepository<SR_CategoryRoom> UCategoryRoom { get; }

        //Payments
        public IRepository<SR_Bill> UBill { get; }
        public IRepository<SR_TypePay> UTypePay { get; }
        public IRepository<SR_Recharge> URecharge { get; }

        // agregates
        public IRepository<SR_TypeDocument> UTypeDocument { get; }
        public IRepository<SR_PeriodBooking> UPeriodBooking { get; }
        public IRepository<SR_State> UState { get; }
        public IRepository<SR_Shift> UShift { get; }
        public IRepository<SR_Gender> UGender { get; }

        Task SaveChanges();
    }
}
