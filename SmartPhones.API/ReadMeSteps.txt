Creating the project using the EFCoreInMemoryRepository
Steps:
1. Create a 'Models' folder --> this contains only the dataMembers of our model

2. Create a class of our model in the folder (SmartPhone)

3. Create a 'Repository' folder --> this contains the main logic for our code

4. Create an an Interface inside the Repository folder (ISmartPhoneRepository) 

5. Define CRUD operations in the interface

6. Create a class inside the repository folder which implements the interface (SmartPhoneRepository)

7. By using QuickActionsAndRefactoring implement the interface

8. Now create a 'Data' folder 

9. Install the nuget package for EFCoreInMemory

10. Create a 'SmartPhoneDbContext' class inside the Data folder and inherit DbContext

11. Write the construtor of SmartPhoneDbContext and Dbset
( 
	    public SmartPhoneDbContext(DbContextOptions options):base(options) { }
	    public DbSet<SmartPhone> smartPhones { get; set; }
)

12. Go to Program class and register the services of interface and dbcontext
(
        builder.Services.AddScoped<ISmartPhoneRepository,SmartPhoneRepository>();
        builder.Services.AddDbContext<SmartPhoneDbContext>(options =>
        {
            options.UseInMemoryDatabase("SmartPhoneDB");
        });
)

13. Now go to the controller folder and create a controller 'SmartPhonesController'

14. Define the ISmartphoneRepository Interface and pass it through the constructor
(     
        ISmartPhoneRepository _smartPhoneRepository;
        public SmartPhonesController(ISmartPhoneRepository smartPhoneRepository)
        {
            _smartPhoneRepository = smartPhoneRepository;
        }
)

15. Now go to the Repository folder's SmartPhoneRepository class and define the SmartPhoneDbContext class and pass it through constructor
(
        SmartPhoneDbContext _smartPhoneDbContext;
        public SmartPhoneRepository(SmartPhoneDbContext smartPhoneDbContext)
        {
            _smartPhoneDbContext = smartPhoneDbContext;
        }
)

16. Now write the actual logic for the CRUD operations in SmartPhoneRepository 

17. After that go to the SmartPhonoesControllers and write code for handling the Http requests