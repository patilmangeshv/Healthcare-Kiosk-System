using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace server_api.Entities
{
    /*
    1. Super admin - S
    Has all the priviledges in the system:
        1- Manage the licensing of the system
        2- Add delete all kind of users on the server
        3- Bloc or enable Kiosks to be operational on the system as well as TVs based on their MAC adresses.
    2. Admin - A
        1- Has the rights to add data to the DB Masters or update / delete them.
        2- Has the right to add or delete Users except other Admins and super Admins
        3- See all the Queues Working, Onhold, desactivated... 
        4- Run KPI analysis on the timing of Minimum waiting time, Maximum waiting time, and average waiting time in the queue of a particular box.
    3. Desk User - U
        1- This login will see the data on the system included in his Desk only (TV, Boxes)
        2- This login will see the queues on the boxes attached the service again to this desk
        3- Can create an appointment on the system inserted on after the last record of that box queue.
        4- See the Queues of that desk which are on hold by the doctors or other system users.
    4. Doctor Use - D
        1- Using the Windows application for Patients call,
        2- Call the patient 1 time, if does not show then call the same 2 more times, if he not shows up, then flag him as noshow and call the next one.
        3- See the Patient details from the Patient table (name, surname, age, medical_file_num.
        4- Hold the queue of his box (only), if he needs to do a side work...
    5. Light User - L
        1- Information Desk users (sometimes called SDHSE users), one queue with multiples callers.
        2- Payment Desk users, one queue with multiples callers.
        3- Just call the patients on the line, Call the patient 1 time, if does not show then call the same 2 more times, if he not shows up, then flag him as noshow and call the next one.
    */
    [Table("tblUser")]
    public class AppUser
    {
        [Column("UserId")]
        public int Id { get; set; }
        [StringLength(50), DataType(DataType.Text)]
        public string UserName { get; set; }
        [StringLength(1), DataType(DataType.Text), Column(TypeName="char(1)")
        , Comment("Super Admin:S, Admin: A, Desk User: U, Doctor User: D, Light Users: L")]
        public string UserLevel { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int? EmployeeId { get; set; }
        public bool IsActive { get; set; }
    }
}