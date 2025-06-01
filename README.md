# AWS-tutorial

## Svrha tutorijala:

Ovaj tutorijal pruža praktični uvod u AWS (Amazon Web Services) i njegove mogućnosti za kreiranje skalabilnih, distribuiranih i serverless sistema. Kroz konkretan primer, u kom se poruke šalju putem SQS reda, obrađuju u Lambda funkciji i rezultati skladište u S3 bucket-u, čitalac će naučiti:

1. Kako da projektuje i implementira serverless arhitekturu koristeći AWS servise.

2. Na koji način SQS omogućava pouzdanu i asinhronu komunikaciju između komponenti sistema.

3. Kako da koristi AWS Lambda funkcije za obradu događaja bez potrebe za održavanjem servera.

4. Kako da koristi S3 kao trajnu memoriju za skladištenje rezultata ili fajlova.

## Šta je AWS i šta pruža

**Amazon Web Services (AWS)** je vodeća cloud platforma koju razvija Amazon, a koja omogućava korisnicima da kreiraju, implementiraju i skaliraju aplikacije korišćenjem servisa dostupnih putem interneta. Umesto da aplikacije hostuju lokalno ili na sopstvenim serverima, korisnici mogu koristiti AWS infrastrukturu „na zahtev“, plaćajući samo resurse koje stvarno koriste.

AWS nudi više od 200 servisa koji pokrivaju širok spektar oblasti, uključujući:

- **Računarsku snagu (Compute)** – npr. EC2 (virtualne mašine), Lambda (serverless funkcije)
- **Skladištenje podataka (Storage)** – npr. S3 (objektno skladište), EBS (blok skladište)
- **Baze podataka (Databases)** – npr. RDS, DynamoDB
- **Mreže i isporuku sadržaja (Networking & CDN)** – npr. VPC, CloudFront
- **Integraciju i obradu podataka** – npr. SQS (red poruka), SNS (notifikacije), Step Functions (orkestracija)

AWS omogućava sledeće prednosti:
- Skalabilnost i fleksibilnost sistema
- Plaćanje po korišćenju (pay-as-you-go model)
- Visoku dostupnost i pouzdanost
- Jednostavnu automatizaciju i integraciju

### Servisi korišćeni u ovom tutorijalu

U okviru ovog tutorijala koristićemo tri osnovna AWS servisa koji čine tipičnu serverless arhitekturu:

- **Amazon SQS (Simple Queue Service)**  
  Omogućava asinhronu komunikaciju između komponenti sistema pomoću redova poruka. Idealno za razdvajanje servisa i obradu zadataka u pozadini.

- **AWS Lambda**  
  Omogućava izvršavanje koda kao reakciju na događaje bez potrebe za pokretanjem i održavanjem servera. Plaća se samo vreme izvršavanja.

- **Amazon S3 (Simple Storage Service)**  
  Skalabilno i pouzdano objektno skladište za čuvanje fajlova, podataka, logova, slika i drugih statičnih resursa.

Korišćenjem ovih servisa, pokazaćemo kako da napravite distribuirani sistem koji prima poruke, obrađuje ih i čuva rezultate – sve bez potrebe za tradicionalnim serverima.


