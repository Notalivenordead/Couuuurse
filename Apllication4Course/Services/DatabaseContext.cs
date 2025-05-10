using Apllication4Course.Models.Reports;
using System.Data.Entity;

namespace Apllication4Course.Services
{
    public class DatabaseContext : DbContext
    {
        private DatabaseContext() : base("name=Apllication4Course.Properties.Settings.BDA_pat_otdConnectionString")
        {
            Database.SetInitializer<DatabaseContext>(null); 
        }

        private static readonly object _lock = new object();
        private static DatabaseContext _instance;

        public static DatabaseContext Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseContext();
                    }
                    return _instance;
                }
            }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Настройка представлений как таблиц
            modelBuilder.Entity<FinancialOperationReport>().ToTable("Мониторинг_Финансовых_Операций").HasKey(x => x.ID_Операции);
            modelBuilder.Entity<ResearchReport>().ToTable("Отчет_Проведенные_Исследования").HasKey(x => x.ID_Исследования);
            modelBuilder.Entity<DeceasedMovementReport>().ToTable("Статистика_Движения_Умерших").HasKey(x => x.ID_Умершего);
        }

        public DbSet<Models.Сотрудники> Сотрудники { get; set; }
        public DbSet<Models.Услуги> Услуги { get; set; }
        public DbSet<Models.Заявки_на_Платные_Услуги> ЗаявкиНаПлатныеУслуги { get; set; }
        public DbSet<Models.Платные_Исследования> ПлатныеИсследования { get; set; }
        public DbSet<Models.Умершие> Умершие { get; set; }
        public DbSet<Models.Камеры_Хранения> КамерыХранения { get; set; }
        public DbSet<Models.Места_В_Камерах> МестаВКамерах { get; set; }
        public DbSet<Models.Журнал_Температур> ЖурналТемператур { get; set; }
        public DbSet<Models.Исследования> Исследования { get; set; }
        public DbSet<Models.Образцы> Образцы { get; set; }
        public DbSet<Models.Использование_Образцов> ИспользованиеОбразцов { get; set; }
        public DbSet<Models.Инвентарь> Инвентарь { get; set; }
        public DbSet<Models.Использование_Инвентаря> ИспользованиеИнвентаря { get; set; }
        public DbSet<Models.Журнал_Обращений> ЖурналОбращений { get; set; }
        public DbSet<Models.Транспортировка> Транспортировка { get; set; }
        public DbSet<Models.Способ_Оплаты> СпособОплаты { get; set; }
        public DbSet<Models.Финансовые_Операции> ФинансовыеОперации { get; set; }
        public DbSet<FinancialOperationReport> FinancialOperations { get; set; }
        public DbSet<ResearchReport> Researches { get; set; }
        public DbSet<DeceasedMovementReport> DeceasedMovements { get; set; }
    }
}