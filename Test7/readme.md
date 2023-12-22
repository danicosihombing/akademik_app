## Petunjuk Penggunaan Aplikasi akademik_app

- Buat database baru di Sql Server yang digunakan
- Sesuaikan Url SqlServer yang digunakan pada file "Program.cs"
- Pada Terminal lakukan Migrasi dengan langkah dibawah ini:
    - Pertama  "dotnet ef migrations add InitialCreate"
    - Kedua "dotnet ef database update"
- Jalankan Aplikasi melalui terminal dengan mengetik "dotnet run"
- Akses endpoint Home di browser : "http://localhost:5025/Home/Index" (sesuaikan)
- Gunakan Aplikasi dengan tombol-tombol yang tersedia

 