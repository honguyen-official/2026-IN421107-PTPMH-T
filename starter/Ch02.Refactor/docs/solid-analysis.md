# Phan tich vi pham SOLID — ClubManager (starter)

File phan tich: Ch02.Refactor/ClubManager.cs.

## 1. SRP — CreateClub lam 3 viec trong 1 method (dong 35)
- Dong nao: dong 35; validate (dong 38-41), luu (dong 44-45), gui thong bao (dong 52-63).
- Nguyen tac: Single Responsibility — mot method chi nen co mot ly do de thay doi.
- Hau qua: sua cach gui mail co the lam hong phan validate; muon tao CLB ma khong gui mail thi khong lam duoc; viet unit test phai test ca 3 viec cung luc.

## 2. DIP — ghi file truc tiep trong logic nghiep vu (dong 48, 79, 94, 111)
- Dong nao: File.AppendAllText o dong 48 (CreateClub), 79 (AddMemberToClub), 94 (CreateEvent), 111 (PrintClubReport).
- Nguyen tac: Dependency Inversion — khong phu thuoc truc tiep vao file system, ma qua abstraction (IAppLogger).
- Hau qua: muon doi sang ghi log ra console/database phai sua 4 cho; chay test se ghi file that ra may; khong gia lap duoc logger khi test.

## 3. OCP — chuoi if/else chon kenh thong bao (dong 52-63)
- Dong nao: dong 52-63, kiem tra "@gmail.com", "@yahoo.com".
- Nguyen tac: Open/Closed — mo de mo rong, dong de sua doi.
- Hau qua: them kenh moi (SMS, Zalo) bat buoc mo method cu ra sua, de gay loi cho code dang chay dung; cang them kenh method cang phinh to. Nen dung Factory.

## 4. SRP — CreateEvent vua tao su kien vua gui mail (dong 88-97)
- Dong nao: dong 88, doan gui mail dong 96-97.
- Nguyen tac: SRP.
- Hau qua: logic tao su kien dinh cung voi viec gui thong bao; nen dung Observer — EventService chi can bao "da tao su kien", ai quan tam thi tu dang ky nhan.

## 5. SRP + OCP — PrintClubReport tron bao cao voi nghiep vu (dong 103-113)
- Dong nao: dong 103, co ghi log o dong 111.
- Nguyen tac: SRP (in bao cao lan ghi log) va OCP (muon xuat CSV phai sua method nay).
- Hau qua: them dinh dang bao cao moi phai sua code cu. Nen dung Strategy: IReportStrategy voi ConsoleReportStrategy, CsvReportStrategy.

## 6. DIP — du lieu luu cung bang List trong class (dong 30-31)
- Dong nao: _clubs, _members o dong 30-31.
- Nguyen tac: DIP — nen phu thuoc vao IClubRepository thay vi List cu the.
- Hau qua: muon chuyen sang luu database phai sua ca class; khong thay the duoc cach luu tru khi test.
