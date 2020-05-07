using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace apbd_cw6.Models
{
    public partial class s18793Context : DbContext
    {
        public s18793Context()
        {
        }

        public s18793Context(DbContextOptions<s18793Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Dydaktyk> Dydaktyk { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Gosc> Gosc { get; set; }
        public virtual DbSet<Grupa> Grupa { get; set; }
        public virtual DbSet<Katedra> Katedra { get; set; }
        public virtual DbSet<Kategoria> Kategoria { get; set; }
        public virtual DbSet<Koszykarz> Koszykarz { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Medicament> Medicament { get; set; }
        public virtual DbSet<OknoTransferowe> OknoTransferowe { get; set; }
        public virtual DbSet<Osoba> Osoba { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Panstwo> Panstwo { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Pokoj> Pokoj { get; set; }
        public virtual DbSet<Pracadyplomowa> Pracadyplomowa { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }
        public virtual DbSet<Procedure> Procedure { get; set; }
        public virtual DbSet<ProcedureAnimal> ProcedureAnimal { get; set; }
        public virtual DbSet<Przedmiot> Przedmiot { get; set; }
        public virtual DbSet<PrzedmiotPoprzedzajacy> PrzedmiotPoprzedzajacy { get; set; }
        public virtual DbSet<Rezerwacja> Rezerwacja { get; set; }
        public virtual DbSet<RokAkademicki> RokAkademicki { get; set; }
        public virtual DbSet<Salgrade> Salgrade { get; set; }
        public virtual DbSet<Sezon> Sezon { get; set; }
        public virtual DbSet<StopnieTytuly> StopnieTytuly { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studies> Studies { get; set; }
        public virtual DbSet<Transfer> Transfer { get; set; }
        public virtual DbSet<Umowa> Umowa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s18793;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.IdAnimal)
                    .HasName("Animal_pk");

                entity.Property(e => e.AdmissionDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.IdOwner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Animal_Owner");
            });

            modelBuilder.Entity<Club>(entity =>
            {
                entity.HasKey(e => e.IdClub)
                    .HasName("Club_pk");

                entity.Property(e => e.IdClub)
                    .HasColumnName("Id_Club")
                    .ValueGeneratedNever();

                entity.Property(e => e.KrajClub)
                    .IsRequired()
                    .HasColumnName("Kraj_Club")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LigaClub)
                    .IsRequired()
                    .HasColumnName("Liga_Club")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MiastoClub)
                    .IsRequired()
                    .HasColumnName("Miasto_Club")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NazwaClub)
                    .IsRequired()
                    .HasColumnName("Nazwa_Club")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DEPT");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Dname)
                    .HasColumnName("DNAME")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Loc)
                    .HasColumnName("LOC")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("Doctor_pk");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Dydaktyk>(entity =>
            {
                entity.HasKey(e => e.IdOsoba)
                    .HasName("Dydaktyk_PK");

                entity.Property(e => e.IdOsoba).ValueGeneratedNever();

                entity.HasOne(d => d.IdKatedraNavigation)
                    .WithMany(p => p.Dydaktyk)
                    .HasForeignKey(d => d.IdKatedra)
                    .HasConstraintName("FK__Dydaktyk__IdKate__55009F39");

                entity.HasOne(d => d.IdOsobaNavigation)
                    .WithOne(p => p.Dydaktyk)
                    .HasForeignKey<Dydaktyk>(d => d.IdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Osoba_Dydaktyk_FK1");

                entity.HasOne(d => d.IdStopienNavigation)
                    .WithMany(p => p.Dydaktyk)
                    .HasForeignKey(d => d.IdStopien)
                    .HasConstraintName("StopnieTytuly_Dydaktyk_FK1");

                entity.HasOne(d => d.PodlegaNavigation)
                    .WithMany(p => p.InversePodlegaNavigation)
                    .HasForeignKey(d => d.Podlega)
                    .HasConstraintName("Dydaktyk_Dydaktyk_FK1");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EMP");

                entity.Property(e => e.Comm).HasColumnName("COMM");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Empno).HasColumnName("EMPNO");

                entity.Property(e => e.Ename)
                    .HasColumnName("ENAME")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("HIREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .HasColumnName("JOB")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Sal).HasColumnName("SAL");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => e.IdEnrollment)
                    .HasName("Enrollment_pk");

                entity.Property(e => e.IdEnrollment).ValueGeneratedNever();

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.IdStudyNavigation)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.IdStudy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Enrollment_Studies");
            });

            modelBuilder.Entity<Gosc>(entity =>
            {
                entity.HasKey(e => e.IdGosc)
                    .HasName("PK__Gosc__8126AB6D07918787");

                entity.Property(e => e.IdGosc).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProcentRabatu).HasColumnName("Procent_rabatu");
            });

            modelBuilder.Entity<Grupa>(entity =>
            {
                entity.HasKey(e => e.IdGrupa)
                    .HasName("Grupa_PK");

                entity.HasIndex(e => new { e.NrGrupy, e.IdRokAkademicki })
                    .HasName("UQ_Rok_Nr")
                    .IsUnique();

                entity.Property(e => e.IdRokAkademicki)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NrGrupy)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdRokAkademickiNavigation)
                    .WithMany(p => p.Grupa)
                    .HasForeignKey(d => d.IdRokAkademicki)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RokAkad_GrupaStud_FK1");
            });

            modelBuilder.Entity<Katedra>(entity =>
            {
                entity.HasKey(e => e.IdKatedra)
                    .HasName("PK__Katedra__43560553C52C61F5");

                entity.HasIndex(e => e.Katedra1)
                    .HasName("UQ_KatedraName")
                    .IsUnique();

                entity.Property(e => e.Katedra1)
                    .IsRequired()
                    .HasColumnName("Katedra")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdOsobaNavigation)
                    .WithMany(p => p.Katedra)
                    .HasForeignKey(d => d.IdOsoba)
                    .HasConstraintName("FK__Katedra__IdOsoba__531856C7");
            });

            modelBuilder.Entity<Kategoria>(entity =>
            {
                entity.HasKey(e => e.IdKategoria)
                    .HasName("PK__Kategori__31412B26506BE522");

                entity.Property(e => e.IdKategoria).ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Koszykarz>(entity =>
            {
                entity.HasKey(e => e.IdKoszykarz)
                    .HasName("Koszykarz_pk");

                entity.Property(e => e.IdKoszykarz)
                    .HasColumnName("Id_Koszykarz")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClubIdClub).HasColumnName("Club_Id_Club");

                entity.Property(e => e.ImieKoszykarz)
                    .IsRequired()
                    .HasColumnName("Imie_Koszykarz")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerIdManager).HasColumnName("Manager_Id_Manager");

                entity.Property(e => e.NarodowoscKoszykarz)
                    .IsRequired()
                    .HasColumnName("Narodowosc_Koszykarz")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NazwiskoKoszykarz)
                    .IsRequired()
                    .HasColumnName("Nazwisko_Koszykarz")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RokUrodzeniaKoszykarz).HasColumnName("RokUrodzenia_Koszykarz");

                entity.HasOne(d => d.ClubIdClubNavigation)
                    .WithMany(p => p.Koszykarz)
                    .HasForeignKey(d => d.ClubIdClub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Koszykarz_Club");

                entity.HasOne(d => d.ManagerIdManagerNavigation)
                    .WithMany(p => p.Koszykarz)
                    .HasForeignKey(d => d.ManagerIdManager)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Koszykarz_Manager");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => e.IdManager)
                    .HasName("Manager_pk");

                entity.Property(e => e.IdManager)
                    .HasColumnName("Id_Manager")
                    .ValueGeneratedNever();

                entity.Property(e => e.ImieManager)
                    .IsRequired()
                    .HasColumnName("Imie_Manager")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NarodowoscManagerNarodowoscManager)
                    .IsRequired()
                    .HasColumnName("Narodowosc_ManagerNarodowosc_Manager")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NazwiskoManager)
                    .IsRequired()
                    .HasColumnName("Nazwisko_Manager")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RokUrodzeniaManager).HasColumnName("RokUrodzenia_Manager");
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament)
                    .HasName("Medicament_pk");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<OknoTransferowe>(entity =>
            {
                entity.HasKey(e => e.SezonIdSezon)
                    .HasName("OknoTransferowe_pk");

                entity.Property(e => e.SezonIdSezon)
                    .HasColumnName("Sezon_Id_Sezon")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.SezonIdSezonNavigation)
                    .WithOne(p => p.OknoTransferowe)
                    .HasForeignKey<OknoTransferowe>(d => d.SezonIdSezon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OknoTransferowe_Sezon");
            });

            modelBuilder.Entity<Osoba>(entity =>
            {
                entity.HasKey(e => e.IdOsoba)
                    .HasName("Osoba_PK");

                entity.Property(e => e.DataUrodzenia).HasColumnType("date");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(62)
                    .IsUnicode(false);

                entity.Property(e => e.Plec).HasColumnType("text");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(e => e.IdOwner)
                    .HasName("Owner_pk");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Panstwo>(entity =>
            {
                entity.HasKey(e => e.IdPanstwo)
                    .HasName("Panstwo_PK");

                entity.Property(e => e.Panstwo1)
                    .IsRequired()
                    .HasColumnName("Panstwo")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient)
                    .HasName("Patient_pk");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Pokoj>(entity =>
            {
                entity.HasKey(e => e.NrPokoju)
                    .HasName("PK__Pokoj__18804ABE487EF079");

                entity.Property(e => e.NrPokoju).ValueGeneratedNever();

                entity.Property(e => e.LiczbaMiejsc).HasColumnName("Liczba_miejsc");

                entity.HasOne(d => d.IdKategoriaNavigation)
                    .WithMany(p => p.Pokoj)
                    .HasForeignKey(d => d.IdKategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pokoj__IdKategor__0B91BA14");
            });

            modelBuilder.Entity<Pracadyplomowa>(entity =>
            {
                entity.HasKey(e => e.IdPraca)
                    .HasName("PK__PRACADYP__C7DA52730379A395");

                entity.ToTable("PRACADYPLOMOWA");

                entity.Property(e => e.DataRoczpoczecia).HasColumnType("date");

                entity.Property(e => e.Tytul)
                    .HasColumnName("tytul")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdOsobaNavigation)
                    .WithMany(p => p.Pracadyplomowa)
                    .HasForeignKey(d => d.IdOsoba)
                    .HasConstraintName("FK__PRACADYPL__IdOso__57DD0BE4");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription)
                    .HasName("Prescription_pk");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Doctor");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Patient");
            });

            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription })
                    .HasName("Prescription_Medicament_pk");

                entity.ToTable("Prescription_Medicament");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdMedicamentNavigation)
                    .WithMany(p => p.PrescriptionMedicament)
                    .HasForeignKey(d => d.IdMedicament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Medicament_Medicament");

                entity.HasOne(d => d.IdPrescriptionNavigation)
                    .WithMany(p => p.PrescriptionMedicament)
                    .HasForeignKey(d => d.IdPrescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Medicament_Prescription");
            });

            modelBuilder.Entity<Procedure>(entity =>
            {
                entity.HasKey(e => e.IdProcedure)
                    .HasName("Procedure_pk");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ProcedureAnimal>(entity =>
            {
                entity.HasKey(e => new { e.ProcedureIdProcedure, e.AnimalIdAnimal, e.Date })
                    .HasName("Procedure_Animal_pk");

                entity.ToTable("Procedure_Animal");

                entity.Property(e => e.ProcedureIdProcedure).HasColumnName("Procedure_IdProcedure");

                entity.Property(e => e.AnimalIdAnimal).HasColumnName("Animal_IdAnimal");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.AnimalIdAnimalNavigation)
                    .WithMany(p => p.ProcedureAnimal)
                    .HasForeignKey(d => d.AnimalIdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_3_Animal");

                entity.HasOne(d => d.ProcedureIdProcedureNavigation)
                    .WithMany(p => p.ProcedureAnimal)
                    .HasForeignKey(d => d.ProcedureIdProcedure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_3_Procedure");
            });

            modelBuilder.Entity<Przedmiot>(entity =>
            {
                entity.HasKey(e => e.IdPrzedmiot)
                    .HasName("Przedmiot_PK");

                entity.Property(e => e.Przedmiot1)
                    .IsRequired()
                    .HasColumnName("Przedmiot")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PrzedmiotPoprzedzajacy>(entity =>
            {
                entity.HasKey(e => new { e.IdPoprzednik, e.IdPrzedmiot })
                    .HasName("PrzedmiotPoprzedzajacy_PK");

                entity.HasOne(d => d.IdPoprzednikNavigation)
                    .WithMany(p => p.PrzedmiotPoprzedzajacyIdPoprzednikNavigation)
                    .HasForeignKey(d => d.IdPoprzednik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Przedmiot_PrzedmiotPop_FK1");

                entity.HasOne(d => d.IdPrzedmiotNavigation)
                    .WithMany(p => p.PrzedmiotPoprzedzajacyIdPrzedmiotNavigation)
                    .HasForeignKey(d => d.IdPrzedmiot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Przedmiot_PrzedmiotPop_FK2");
            });

            modelBuilder.Entity<Rezerwacja>(entity =>
            {
                entity.HasKey(e => e.IdRezerwacja)
                    .HasName("PK__Rezerwac__68F5E1865BF46C5B");

                entity.Property(e => e.IdRezerwacja).ValueGeneratedNever();

                entity.Property(e => e.DataDo).HasColumnType("datetime");

                entity.Property(e => e.DataOd).HasColumnType("datetime");

                entity.HasOne(d => d.IdGoscNavigation)
                    .WithMany(p => p.Rezerwacja)
                    .HasForeignKey(d => d.IdGosc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rezerwacj__IdGos__0E6E26BF");

                entity.HasOne(d => d.NrPokojuNavigation)
                    .WithMany(p => p.Rezerwacja)
                    .HasForeignKey(d => d.NrPokoju)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rezerwacj__NrPok__0F624AF8");
            });

            modelBuilder.Entity<RokAkademicki>(entity =>
            {
                entity.HasKey(e => e.IdRokAkademicki)
                    .HasName("RokAkademicki_PK");

                entity.Property(e => e.IdRokAkademicki)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DataRozp)
                    .HasColumnName("Data_rozp")
                    .HasColumnType("date");

                entity.Property(e => e.DataZak)
                    .HasColumnName("Data_zak")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Salgrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SALGRADE");

                entity.Property(e => e.Grade).HasColumnName("GRADE");

                entity.Property(e => e.Hisal).HasColumnName("HISAL");

                entity.Property(e => e.Losal).HasColumnName("LOSAL");
            });

            modelBuilder.Entity<Sezon>(entity =>
            {
                entity.HasKey(e => e.IdSezon)
                    .HasName("Sezon_pk");

                entity.Property(e => e.IdSezon)
                    .HasColumnName("Id_Sezon")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StopnieTytuly>(entity =>
            {
                entity.HasKey(e => e.IdStopien)
                    .HasName("StopnieTytuly_PK");

                entity.Property(e => e.Skrot)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Stopien)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IndexNumber)
                    .HasName("Student_pk");

                entity.Property(e => e.IndexNumber).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdEnrollmentNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.IdEnrollment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_Enrollment");
            });

            modelBuilder.Entity<Studies>(entity =>
            {
                entity.HasKey(e => e.IdStudy)
                    .HasName("Studies_pk");

                entity.Property(e => e.IdStudy).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Transfer>(entity =>
            {
                entity.HasKey(e => e.NrTransferu)
                    .HasName("Transfer_pk");

                entity.Property(e => e.NrTransferu).ValueGeneratedNever();

                entity.Property(e => e.Club2IdClub).HasColumnName("Club_2_Id_Club");

                entity.Property(e => e.ClubIdClub).HasColumnName("Club_Id_Club");

                entity.Property(e => e.KoszykarzIdKoszykarz).HasColumnName("Koszykarz_Id_Koszykarz");

                entity.Property(e => e.OknoTransferoweSezonIdSezon)
                    .IsRequired()
                    .HasColumnName("OknoTransferowe_Sezon_Id_Sezon")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Club2IdClubNavigation)
                    .WithMany(p => p.TransferClub2IdClubNavigation)
                    .HasForeignKey(d => d.Club2IdClub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Transfer_Club_2");

                entity.HasOne(d => d.ClubIdClubNavigation)
                    .WithMany(p => p.TransferClubIdClubNavigation)
                    .HasForeignKey(d => d.ClubIdClub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Transfer_Club");

                entity.HasOne(d => d.KoszykarzIdKoszykarzNavigation)
                    .WithMany(p => p.Transfer)
                    .HasForeignKey(d => d.KoszykarzIdKoszykarz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Transfer_Koszykarz");

                entity.HasOne(d => d.OknoTransferoweSezonIdSezonNavigation)
                    .WithMany(p => p.Transfer)
                    .HasForeignKey(d => d.OknoTransferoweSezonIdSezon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Transfer_OknoTransferowe");
            });

            modelBuilder.Entity<Umowa>(entity =>
            {
                entity.HasKey(e => e.NrUmowy)
                    .HasName("Umowa_pk");

                entity.Property(e => e.NrUmowy).ValueGeneratedNever();

                entity.Property(e => e.DataPodpisania).HasColumnType("date");

                entity.Property(e => e.DataStart).HasColumnType("date");

                entity.Property(e => e.Datakoniec).HasColumnType("date");

                entity.Property(e => e.KoszykarzIdKoszykarz).HasColumnName("Koszykarz_Id_Koszykarz");

                entity.HasOne(d => d.KoszykarzIdKoszykarzNavigation)
                    .WithMany(p => p.Umowa)
                    .HasForeignKey(d => d.KoszykarzIdKoszykarz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Umowa_Koszykarz");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
