using EduHub.Ch02.Logging;
using EduHub.Ch02.Notifications;
using EduHub.Ch02.Patterns.Observers;
using EduHub.Ch02.Patterns.Strategies;
using EduHub.Ch02.Repositories;
using EduHub.Ch02.Services;

// Composition root: noi DUY NHAT new cac class cu the.
IAppLogger logger = new ConsoleLogger();

// Decorator: boc repository bang LoggingClubRepository de tu dong ghi log moi lan truy cap.
IClubRepository clubRepo = new LoggingClubRepository(new InMemoryClubRepository(), logger);
IMemberRepository memberRepo = new InMemoryMemberRepository();
IEventRepository eventRepo = new InMemoryEventRepository();

// Factory: 1 cho duy nhat de tao notifier theo kenh.
INotificationServiceFactory notificationFactory = new NotificationServiceFactory();

var clubService = new ClubService(clubRepo, memberRepo, logger, notificationFactory);
var eventService = new EventService(clubRepo, eventRepo, logger);

// Observer: dang ky nhan tin khi co su kien moi.
eventService.Subscribe(new LogNotifier(logger));
eventService.Subscribe(new EmailNotifier(
    notificationFactory.Create(NotificationChannel.Email), "president@gmail.com"));

var reportService = new ReportService(clubRepo, memberRepo);

var club = clubService.CreateClub("Tech Club", "Cau lac bo cong nghe", "president@gmail.com");
clubService.AddMemberToClub(club.Id, "Nguyen Van A", "a@student.dthu.edu.vn");
eventService.CreateEvent(club.Id, "Workshop SOLID", new DateTime(2026, 11, 20));

// Strategy: cung du lieu, 2 cach xuat khac nhau.
reportService.GenerateReport(new ConsoleReportStrategy());
reportService.GenerateReport(new CsvReportStrategy());
