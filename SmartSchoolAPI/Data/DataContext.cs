using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchoolAPI.models;

namespace SmartSchoolAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoDisciplina>().HasKey(ad => new { ad.AlunoId, ad.DisciplinaId });


            modelBuilder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new Professor(1, "Lauro"),
                    new Professor(2, "Soares"),
                    new Professor(3, "Marconi"),
                    new Professor(4, "Carvalho"),
                    new Professor(5, "Montanha"),
                });

            modelBuilder.Entity<Disciplina>()
                .HasData(new List<Disciplina>{
                    new Disciplina(1, "Matemática", 1),
                    new Disciplina(2, "Matemática", 1),
                    new Disciplina(3, "Física", 2),
                    new Disciplina(4, "Português", 3),
                    new Disciplina(5, "Inglês", 4),
                    new Disciplina(6, "Inglês", 4),
                    new Disciplina(7, "Inglês", 4),
                    new Disciplina(8, "Programação", 5),
                    new Disciplina(9, "Programação", 5),
                    new Disciplina(10, "Programação", 5)
                });

            modelBuilder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new Aluno(1, "Marta", "Kent", "33225555"),
                    new Aluno(2, "Paula", "Isabela", "3354288"),
                    new Aluno(3, "Laura", "Antonia", "55668899"),
                    new Aluno(4, "Luiza", "Maria", "6565659"),
                    new Aluno(5,"Lucas", "Machado", "565685415"),
                    new Aluno(6, "Pedro", "Alvares", "456454545"),
                    new Aluno(7, "Paulo", "José", "9874512")
                });

            modelBuilder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>() {
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 5 }
                });
        }

    }
}