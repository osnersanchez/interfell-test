namespace Repository.Migrations
{
    using Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApiContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Customer Seeding
            context.Customers.AddOrUpdate(x => x.Id,
                new Customer()
                {
                    Id = 1,
                    Name = "Osner Sanchez",
                    Address = "Venezuela",
                    CustomerCode = 155111,
                    Phone = "+581234567",
                    RentedGames = new List<GameRent>()
                    {
                        new GameRent()
                {
                   Id = 1,
                   CustomerId = 1,
                   GameId = 1,
                   RentalDate = DateTime.Now
                },
                        new GameRent()
                        {
                            Id = 2,
                            CustomerId = 1,
                            GameId = 1,
                            RentalDate = DateTime.Now.AddDays(-7)
                        },
                        new GameRent()
                        {
                            Id = 3,
                            CustomerId = 1,
                            GameId = 2,
                            RentalDate = DateTime.Now.AddDays(-5)
                        },
                        new GameRent()
                        {
                            Id = 4,
                            CustomerId = 1,
                            GameId = 3,
                            RentalDate = DateTime.Now
                        },
                        new GameRent()
                        {
                            Id = 5,
                            CustomerId = 1,
                            GameId = 3,
                            RentalDate = DateTime.Now.AddDays(-10)
                        },
                        new GameRent()
                        {
                            Id = 6,
                            CustomerId = 1,
                            GameId = 4,
                            RentalDate = DateTime.Now.AddDays(-10)
                        },
                        new GameRent()
                        {
                            Id = 7,
                            CustomerId = 1,
                            GameId = 2,
                            RentalDate = DateTime.Now.AddDays(-9)
                        },
                        new GameRent()
                        {
                            Id = 8,
                            CustomerId = 1,
                            GameId = 1,
                            RentalDate = DateTime.Now.AddDays(-15)
                        },
                    }
                },
                new Customer()
                {
                    Id = 2,
                    Name = "Carlos Veliz",
                    Address = "Venezuela",
                    CustomerCode = 155112,
                    Phone = "+581234567",
                    RentedGames = new List<GameRent>()
                    {
                        new GameRent()
                        {
                            Id = 9,
                            CustomerId = 2,
                            GameId = 4,
                            RentalDate = DateTime.Now.AddDays(-15)
                        },
                        new GameRent()
                        {
                            Id = 10,
                            CustomerId = 2,
                            GameId = 3,
                            RentalDate = DateTime.Now.AddDays(-15)
                        }

                    }
                },
                new Customer()
                {
                    Id = 3,
                    Name = "Juan Guaidó",
                    Address = "Venezuela",
                    CustomerCode = 155113,
                    Phone = "+581234567",
                    RentedGames = new List<GameRent>()
                    {
                        new GameRent()
                        {
                            Id = 10,
                            CustomerId = 3,
                            GameId = 3,
                            RentalDate = DateTime.Now.AddDays(-15)
                        }
                    }
                }
                );

            //Game Genres
            context.GameTypes.AddOrUpdate(x => x.Id,
                new GameType()
                {
                    Id = 1,
                    Title = "Simulación"
                },
                new GameType()
                {
                    Id = 2,
                    Title = "RPG"
                },
                new GameType()
                {
                    Id = 3,
                    Title = "Aventura"
                },
                new GameType()
                {
                    Id = 4,
                    Title = "Terror"
                }
                );

            //Games
            context.Games.AddOrUpdate(x => x.Id,
                new Game()
                {
                    Id = 1,
                    Name = "Fortnite",
                    Description = "Fortnite es un videojuego del año 2017 desarrollado por la empresa Epic Games, lanzado como diferentes paquetes de software que presentan diferentes modos de juego, pero que comparten el mismo motor general de juego y las mecánicas. Fue anunciado en los Spike Video Game Awards en 2011.",
                    GameTypeId = 1
                },
                new Game()
                {
                    Id = 2,
                    Name = "Anthem",
                    Description = "Anthem es un videojuego de mundo semi-abierto desarrollado por Bioware, creadores de Mass Effect y Dragon Age, y distribuido por Electronic Arts, que utilizará el motor gráfico Frostbite. El título está en desarrollo para las plataformas PlayStation 4, Xbox One y Microsoft Windows.",
                    GameTypeId = 2
                },
                new Game()
                {
                    Id = 3,
                    Name = "Spore",
                    Description = "Spore es un videojuego de simulación de vida y estrategia para Apple Macintosh y Microsoft Windows desarrollado por Maxis y diseñado por Will Wright que simula la evolución de una especie desde las etapas más primitivas, hasta la colonización de la galaxia por parte del ser evolucionado.",
                    GameTypeId = 3
                },
                new Game()
                {
                    Id = 4,
                    Name = "Minecraft",
                    Description = "Minecraft es un videojuego de construcción, de tipo «mundo abierto» o sandbox creado originalmente por el sueco Markus Persson, ​ y posteriormente desarrollado por su empresa, Mojang AB.",
                    GameTypeId = 4
                }
                );
        }
    }
}
