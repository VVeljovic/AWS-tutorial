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

U okviru ovog tutorijala koristićemo tri osnovna AWS servisa koji zajedno omogućavaju kreiranje skalabilnog i serverless sistema: **Amazon SQS**, **AWS Lambda**, i **Amazon S3**. U nastavku je detaljan opis svakog od njih.

---
#### 📬 Amazon SQS (Simple Queue Service)

Amazon SQS je **fully managed** servis za razmenu poruka između komponenti sistema. Pruža mogućnost da jedan servis pošalje poruku u red, dok drugi servis (npr. Lambda funkcija ili neki ECS servis) može tu poruku da pročita i obradi – sve to bez direktne međuzavisnosti između tih komponenti.

**Osnovne karakteristike:**
- Decoupling (razdvajanje) servisa – omogućava nezavisno skaliranje i razvoj različitih delova sistema.
- Pouzdana isporuka poruka – garantuje da nijedna poruka neće biti izgubljena (uz pravilno konfigurisane retry mehanizme).
- Podržava FIFO redove za garantovani redosled poruka.
- Jednostavno podešavanje prava pristupa i bezbednosti putem IAM politika.
---
#### ⚙️ AWS Lambda

AWS Lambda omogućava izvršavanje funkcija u cloudu **bez potrebe za upravljanjem serverima**. Dovoljno je napisati kod za Lambda funkciju, definisati trigger i AWS se brine o svemu ostalom – skaliranju, održavanju, resursima i naplati.

**Osnovne karakteristike:**
- Potpuno serverless – korisnik ne brine o infrastrukturi.
- Automatsko skaliranje – Lambda funkcije se pokreću on-demand za svaku poruku.
- Integracija sa brojnim AWS servisima – uključujući SQS, S3, API Gateway i druge.
- Naplata po broju poziva i trajanju izvršavanja funkcije.
---

#### 🗂️ Amazon S3 (Simple Storage Service)

Amazon S3 je skalabilni sistem za skladištenje podataka koji omogućava čuvanje bilo koje vrste fajlova – od tekstualnih dokumenata i slika, do logova i binarnih podataka.

**Osnovne karakteristike:**
- Visoka dostupnost i otpornost na greške (objekti se čuvaju redundantno).
- Skalabilnost bez potrebe za manuelnim podešavanjem kapaciteta.
- Verzionisanje i kontrola pristupa.
- Jednostavna integracija sa drugim AWS servisima, uključujući Lambda, CloudFront, Athena i druge.
---
