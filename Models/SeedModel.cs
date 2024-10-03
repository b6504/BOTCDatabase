namespace BOTCDatabase.Models;
using Microsoft.EntityFrameworkCore;
using BOTCDatabase.Data;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Routing.Constraints;

public static class SeedData
{

    public static int InitializeTownsfolk(IServiceProvider serviceProvider, IWebHostEnvironment webHostEnvironment, string ListofTownsfolk, string iconPath, string descriptionPath, string tipsPath)
    {
        // Paths in format 'xxx/yyy/'
        using (var context = new BludContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BludContext>>()))
        {
            if (context == null || context.Role == null)
            {
                throw new ArgumentNullException("Null Context");
            }
            if (context.Role.Any())
            {
                return 1;
            }

            string characterName; // Name of character
            string characterDesc; // Basic description
            
            StreamReader sReader = new StreamReader(Path.Combine(webHostEnvironment.WebRootPath, ListofTownsfolk));

            characterName = sReader.ReadLine();
            while (characterName != null)
            {
                string characterFileName = characterName.Replace("\'", "").Replace(' ', '_');
                string characterDescFile = $"{descriptionPath}Townsfolk/{characterFileName}.txt";

                StreamReader descReader = new StreamReader(Path.Combine(webHostEnvironment.WebRootPath, characterDescFile));

                characterDesc = descReader.ReadLine(); // Format description slightly
                
                if (characterDesc == null)
                {
                    characterDesc = "";
                }
                context.Role.AddRange(
                    new Role
                    {
                        Name = characterName,
                        ImagePath = $"/{iconPath}Townsfolk/{characterFileName}.png",
                        DescPath = $"/{characterDescFile}",
                        TipsPath = $"/{tipsPath}Townsfolk/{characterFileName}.txt",
                        Type = CharacterType.Townsfolk,
                        Description = characterDesc.Replace("\"", "")
                    }
                );
                characterName = sReader.ReadLine();
            }
            
            context.SaveChanges();
            return 0;
        }
    }
    public static void InitializeOutsiders(IServiceProvider serviceProvider, IWebHostEnvironment webHostEnvironment, string ListofOutsiders, string iconPath, string descriptionPath, string tipsPath)
    {
        // Paths in format 'xxx/yyy/'
        using (var context = new BludContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BludContext>>()))
        {
            if (context == null || context.Role == null)
            {
                throw new ArgumentNullException("Null Context");
            }

            string characterName; // Name of character
            string characterDesc; // Basic description

            StreamReader sReader = new StreamReader(Path.Combine(webHostEnvironment.WebRootPath, ListofOutsiders));

            characterName = sReader.ReadLine();
            while (characterName != null)
            {
                string characterFileName = characterName.Replace("\'", "").Replace(' ', '_');
                string characterDescFile = $"{descriptionPath}Outsiders/{characterFileName}.txt";
                StreamReader descReader = new StreamReader(Path.Combine(webHostEnvironment.WebRootPath, characterDescFile));

                characterDesc = descReader.ReadLine(); // Format description slightly
                if (characterDesc == null)
                {
                    characterDesc = "";
                }
                context.Role.AddRange(
                    new Role
                    {
                        Name = characterName,
                        ImagePath = $"/{iconPath}Outsiders/{characterFileName}.png",
                        DescPath = $"/{characterDescFile}",
                        TipsPath = $"/{tipsPath}Outsiders/{characterFileName}.txt",
                        Type = CharacterType.Outsider,
                        Description = characterDesc.Replace("\"", "")
                    }
                );
                characterName = sReader.ReadLine();
            }

            context.SaveChanges();
        }
    }
    public static void InitializeMinions(IServiceProvider serviceProvider, IWebHostEnvironment webHostEnvironment, string ListofMinions, string iconPath, string descriptionPath, string tipsPath)
    {
        // Paths in format 'xxx/yyy/'
        using (var context = new BludContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BludContext>>()))
        {
            if (context == null || context.Role == null)
            {
                throw new ArgumentNullException("Null Context");
            }

            string characterName; // Name of character
            string characterDesc; // Basic description

            StreamReader sReader = new StreamReader(Path.Combine(webHostEnvironment.WebRootPath, ListofMinions));

            characterName = sReader.ReadLine();
            while (characterName != null)
            {
                string characterFileName = characterName.Replace("\'", "").Replace(' ', '_');
                string characterDescFile = $"{descriptionPath}Minions/{characterFileName}.txt";
                StreamReader descReader = new StreamReader(Path.Combine(webHostEnvironment.WebRootPath, characterDescFile));
                
                characterDesc = descReader.ReadLine(); // Format description slightly
                if (characterDesc == null)
                {
                    characterDesc = "";
                }
                context.Role.AddRange(
                    new Role
                    {
                        Name = characterName,
                        ImagePath = $"/{iconPath}Minions/{characterFileName}.png",
                        DescPath = $"/{characterDescFile}",
                        TipsPath = $"/{tipsPath}Minions/{characterFileName}.txt",
                        Type = CharacterType.Minion,
                        Description = characterDesc.Replace("\"", "")
                    }
                );
                characterName = sReader.ReadLine();
            }

            context.SaveChanges();
        }
    }
    public static void InitializeDemons(IServiceProvider serviceProvider, IWebHostEnvironment webHostEnvironment, string ListofDemons, string iconPath, string descriptionPath, string tipsPath)
    {
        // Paths in format 'xxx/yyy/'
        using (var context = new BludContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BludContext>>()))
        {
            if (context == null || context.Role == null)
            {
                throw new ArgumentNullException("Null Context");
            }

            string characterName; // Name of character
            string characterDesc; // Basic description

            StreamReader sReader = new StreamReader(Path.Combine(webHostEnvironment.WebRootPath, ListofDemons));

            characterName = sReader.ReadLine();
            while (characterName != null)
            {
                string characterFileName = characterName.Replace("\'", "").Replace(' ', '_');
                string characterDescFile = $"{descriptionPath}Demons/{characterFileName}.txt";
                StreamReader descReader = new StreamReader(Path.Combine(webHostEnvironment.WebRootPath, characterDescFile));

                characterDesc = descReader.ReadLine(); // Format description slightly
                if (characterDesc == null)
                {
                    characterDesc = "";
                }
                context.Role.AddRange(
                    new Role
                    {
                        Name = characterName,
                        ImagePath = $"/{iconPath}Demons/{characterFileName}.png",
                        DescPath = $"/{characterDescFile}",
                        TipsPath = $"/{tipsPath}Demons/{characterFileName}.txt",
                        Type = CharacterType.Demon,
                        Description = characterDesc.Replace("\"", "")
                    }
                );
                characterName = sReader.ReadLine();
            }

            context.SaveChanges();
        }
    }
    public static void InitializeTravellers(IServiceProvider serviceProvider, IWebHostEnvironment webHostEnvironment, string ListofTravellers, string iconPath, string descriptionPath, string tipsPath)
    {
        // Paths in format 'xxx/yyy/'
        using (var context = new BludContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BludContext>>()))
        {
            if (context == null || context.Role == null)
            {
                throw new ArgumentNullException("Null Context");
            }

            string characterName; // Name of character
            string characterDesc; // Basic description

            StreamReader sReader = new StreamReader(Path.Combine(webHostEnvironment.WebRootPath, ListofTravellers));

            characterName = sReader.ReadLine();
            while (characterName != null)
            {
                string characterFileName = characterName.Replace("\'", "").Replace(' ', '_');
                string characterDescFile = $"{descriptionPath}Travellers/{characterFileName}.txt";
                StreamReader descReader = new StreamReader(Path.Combine(webHostEnvironment.WebRootPath, characterDescFile));

                characterDesc = descReader.ReadLine(); // Format description slightly
                if (characterDesc == null)
                {
                    characterDesc = "";
                }
                context.Role.AddRange(
                    new Role
                    {
                        Name = characterName,
                        ImagePath = $"/{iconPath}Travellers/{characterFileName}.png",
                        DescPath = $"/{characterDescFile}",
                        TipsPath = $"/{tipsPath}Travellers/{characterFileName}.txt",
                        Type = CharacterType.Traveller,
                        Description = characterDesc.Replace("\"", "")
                    }
                );
                characterName = sReader.ReadLine();
            }

            context.SaveChanges();
        }
    }
    public static void InitializeFabled(IServiceProvider serviceProvider, IWebHostEnvironment webHostEnvironment, string ListofFabled, string iconPath, string descriptionPath, string tipsPath)
    {
        // Paths in format 'xxx/yyy/'
        using (var context = new BludContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BludContext>>()))
        {
            if (context == null || context.Role == null)
            {
                throw new ArgumentNullException("Null Context");
            }

            string characterName; // Name of character
            string characterDesc; // Basic description

            StreamReader sReader = new StreamReader(Path.Combine(webHostEnvironment.WebRootPath, ListofFabled));

            characterName = sReader.ReadLine();
            while (characterName != null)
            {
                string characterFileName = characterName.Replace("\'", "").Replace(' ', '_');
                string characterDescFile = $"{descriptionPath}Fabled/{characterFileName}.txt";
                StreamReader descReader = new StreamReader(Path.Combine(webHostEnvironment.WebRootPath, characterDescFile));

                characterDesc = descReader.ReadLine(); // Format description slightly
                if (characterDesc == null)
                {
                    characterDesc = "";
                }
                context.Role.AddRange(
                    new Role
                    {
                        Name = characterName,
                        ImagePath = $"/{iconPath}Fabled/{characterFileName}.png",
                        DescPath = $"/{characterDescFile}",
                        TipsPath = $"/{tipsPath}Fabled/{characterFileName}.txt",
                        Type = CharacterType.Fabled,
                        Description = characterDesc.Replace("\"", ""),
                        FirstNightOrder = -1,
                        OtherNightOrder = -1
                    }
                );
                characterName = sReader.ReadLine();
            }

            context.SaveChanges();
        }
    }
}