using Backend.DAL.Entities;

namespace Backend.Services.Context;

public class AddingEntitiesToDb
{
    // public static string AddChapters(FirstCusrHelpAppContext dbContext)
    // {
    //     var res = new List<Chapter>()
    //     {
    //         new Chapter() { Id = Guid.NewGuid(), Name = "1-е сентября - знакомство", SuccessRate = 0, Order = 1 },
    //         new Chapter() { Id = Guid.NewGuid(), Name = "Выбор предметов в модеусе", SuccessRate = 0, Order = 2 },
    //         new Chapter() { Id = Guid.NewGuid(), Name = "Первая пара", SuccessRate = 0, Order = 3 },
    //         new Chapter() { Id = Guid.NewGuid(), Name = "Процесс обучения", SuccessRate = 0, Order = 4 },
    //         new Chapter() { Id = Guid.NewGuid(), Name = "Это страшное слово - \"сессия\"", SuccessRate = 0, Order = 5 },
    //     };
    //     dbContext.Chapters.AddRange(res);
    //     dbContext.SaveChanges();
    //     return "Ok";
    // }

    // public static string AddSubChapters(FirstCusrHelpAppContext dbContext)
    // {
    //     var res = new List<SubChapter>()
    //     {
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Кто был на линейке?", Order = 1, IsCompleted = false, ChapterId = Guid.Parse("8005986D-6FEE-4A84-8687-F16AFE06A813")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Первая встреча с группой", Order = 2, IsCompleted = false, ChapterId = Guid.Parse("8005986D-6FEE-4A84-8687-F16AFE06A813")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Как работает ИОТ?", Order = 1, IsCompleted = false, ChapterId = Guid.Parse("31E23BB8-0B94-4442-BD5A-480D0123367B")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Знакомство с модеусом", Order = 2, IsCompleted = false, ChapterId = Guid.Parse("31E23BB8-0B94-4442-BD5A-480D0123367B")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Составим оптимальное расписание", Order = 3, IsCompleted = false, ChapterId = Guid.Parse("31E23BB8-0B94-4442-BD5A-480D0123367B")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Как найти информацию о предметах", Order = 4, IsCompleted = false, ChapterId = Guid.Parse("31E23BB8-0B94-4442-BD5A-480D0123367B")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Как найти аудиторию?", Order = 1, IsCompleted = false, ChapterId = Guid.Parse("B4842D2E-7B1A-4B2F-9869-BB4913226729")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Знакомство с командами", Order = 2, IsCompleted = false, ChapterId = Guid.Parse("B4842D2E-7B1A-4B2F-9869-BB4913226729")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Как общаться с преподавателями?", Order = 3, IsCompleted = false, ChapterId = Guid.Parse("B4842D2E-7B1A-4B2F-9869-BB4913226729")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Успеть поесть на \"большаке\"", Order = 4, IsCompleted = false, ChapterId = Guid.Parse("B4842D2E-7B1A-4B2F-9869-BB4913226729")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Про онлайн курсы", Order = 1, IsCompleted = false, ChapterId = Guid.Parse("951D0CBD-3013-4706-A7C8-8922A74A090A")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Тайм-менеджмент", Order = 2, IsCompleted = false, ChapterId = Guid.Parse("951D0CBD-3013-4706-A7C8-8922A74A090A")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Как решать проблемы", Order = 3, IsCompleted = false, ChapterId = Guid.Parse("951D0CBD-3013-4706-A7C8-8922A74A090A")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Самообучение", Order = 4, IsCompleted = false, ChapterId = Guid.Parse("951D0CBD-3013-4706-A7C8-8922A74A090A")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "БРС", Order = 5, IsCompleted = false, ChapterId = Guid.Parse("951D0CBD-3013-4706-A7C8-8922A74A090A")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Про автоматы", Order = 1, IsCompleted = false, ChapterId = Guid.Parse("6B47B22B-71C6-447B-B470-C78AD0458A12")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Как подготовиться к экзамену", Order = 2, IsCompleted = false, ChapterId = Guid.Parse("6B47B22B-71C6-447B-B470-C78AD0458A12")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Выбор  дат экзаменов", Order = 3, IsCompleted = false, ChapterId = Guid.Parse("6B47B22B-71C6-447B-B470-C78AD0458A12")},
    //         new SubChapter{ Id = Guid.NewGuid(), Name = "Как себя вести на экзамене", Order = 4, IsCompleted = false, ChapterId = Guid.Parse("6B47B22B-71C6-447B-B470-C78AD0458A12")},
    //     };
    //     dbContext.SubChapters.AddRange(res);
    //     dbContext.SaveChanges();
    //     return"Ok"; 
    // }

    // public static string AddTests(FirstCusrHelpAppContext dbContext)
    // {
    //     var res = new List<Test>()
    //     {
    //         new Test{Id = Guid.NewGuid(), Order = 1, ChapterId = Guid.Parse("8005986D-6FEE-4A84-8687-F16AFE06A813")},
    //         new Test{Id = Guid.NewGuid(), Order = 2, ChapterId = Guid.Parse("31E23BB8-0B94-4442-BD5A-480D0123367B")},
    //         new Test{Id = Guid.NewGuid(), Order = 3, ChapterId = Guid.Parse("B4842D2E-7B1A-4B2F-9869-BB4913226729")},
    //         new Test{Id = Guid.NewGuid(), Order = 4, ChapterId = Guid.Parse("951D0CBD-3013-4706-A7C8-8922A74A090A")},
    //         new Test{Id = Guid.NewGuid(), Order = 5, ChapterId = Guid.Parse("6B47B22B-71C6-447B-B470-C78AD0458A12")},
    //     };
    //     
    //     dbContext.Tests.AddRange(res);
    //     dbContext.SaveChanges();
    //     
    //     return "Ok";
    // }

    // public static string AddQuestions(FirstCusrHelpAppContext dbContext)
    // {
    //     var res = new List<Question>()
    //     {
    //         new Question{ Id = Guid.NewGuid(), QuestionText = "Как зовут директора ИРИТ-РТФ?", TestId = Guid.Parse("F5C87ADF-9602-4E54-B806-B35A7613B04E")},
    //         new Question{ Id = Guid.NewGuid(), QuestionText = "Кто лучший фронтендер?", TestId = Guid.Parse("F5C87ADF-9602-4E54-B806-B35A7613B04E")},
    //         new Question{ Id = Guid.NewGuid(), QuestionText = "Кто лучший бекендер?", TestId = Guid.Parse("F5C87ADF-9602-4E54-B806-B35A7613B04E")},
    //         new Question{ Id = Guid.NewGuid(), QuestionText = "Как зовут собаку лучшего фронтендера?", TestId = Guid.Parse("F5C87ADF-9602-4E54-B806-B35A7613B04E")},
    //         new Question{ Id = Guid.NewGuid(), QuestionText = "Кто лучшая команда?", TestId = Guid.Parse("F5C87ADF-9602-4E54-B806-B35A7613B04E")},
    //     };
    //     
    //     dbContext.Questions.AddRange(res);
    //     dbContext.SaveChanges();
    //     
    //     return "Ok";
    // }

    // public static string AddAnsweres(FirstCusrHelpAppContext dbContext)
    // {
    //     var res = new List<Answer>()
    //     {
    //         new Answer{ Id = Guid.NewGuid(), Text = "Обабков Иван Николаевич", IsRightAnswer = false, QuestionId = Guid.Parse("6EAC4A96-CEB1-4EFF-AB88-A47A3ED87496")},
    //         new Answer{ Id = Guid.NewGuid(), Text = "Обабков Илья Иванович", IsRightAnswer = false, QuestionId = Guid.Parse("6EAC4A96-CEB1-4EFF-AB88-A47A3ED87496")},
    //         new Answer{ Id = Guid.NewGuid(), Text = "Обабков Илья Николаевич", IsRightAnswer = true, QuestionId = Guid.Parse("6EAC4A96-CEB1-4EFF-AB88-A47A3ED87496")},
    //         new Answer{ Id = Guid.NewGuid(), Text = "Катя", IsRightAnswer = false, QuestionId = Guid.Parse("56279E07-605B-4C87-8FE5-560EDEA2535F")},
    //         new Answer{ Id = Guid.NewGuid(), Text = "Ирина", IsRightAnswer = false, QuestionId = Guid.Parse("56279E07-605B-4C87-8FE5-560EDEA2535F")},
    //         new Answer{ Id = Guid.NewGuid(), Text = "Настя", IsRightAnswer = true, QuestionId = Guid.Parse("56279E07-605B-4C87-8FE5-560EDEA2535F")},
    //         new Answer{ Id = Guid.NewGuid(), Text = "Никита", IsRightAnswer = true, QuestionId = Guid.Parse("8B695459-7C52-40F6-8CAB-F63C4148EB1E")},
    //         new Answer{ Id = Guid.NewGuid(), Text = "Паша", IsRightAnswer = false, QuestionId = Guid.Parse("8B695459-7C52-40F6-8CAB-F63C4148EB1E")},
    //         new Answer{ Id = Guid.NewGuid(), Text = "Кирил", IsRightAnswer = false, QuestionId = Guid.Parse("8B695459-7C52-40F6-8CAB-F63C4148EB1E")},
    //         new Answer{ Id = Guid.NewGuid(), Text = "Рик", IsRightAnswer = true, QuestionId = Guid.Parse("5F8CFE2C-2159-4E46-9BF5-FA7EFEC42C8E")},
    //         new Answer{ Id = Guid.NewGuid(), Text = "Крик", IsRightAnswer = false, QuestionId = Guid.Parse("5F8CFE2C-2159-4E46-9BF5-FA7EFEC42C8E")},
    //         new Answer{ Id = Guid.NewGuid(), Text = "Парик", IsRightAnswer = false, QuestionId = Guid.Parse("5F8CFE2C-2159-4E46-9BF5-FA7EFEC42C8E")},
    //         new Answer{ Id = Guid.NewGuid(), Text = "Валя и Галя", IsRightAnswer = false, QuestionId = Guid.Parse("02FEAA5F-590F-41C4-8151-C5EBE01B0EBA")},
    //         new Answer{ Id = Guid.NewGuid(), Text = "Настя и Никита", IsRightAnswer = true, QuestionId = Guid.Parse("02FEAA5F-590F-41C4-8151-C5EBE01B0EBA")},
    //         new Answer{ Id = Guid.NewGuid(), Text = "Рая и Ада", IsRightAnswer = false, QuestionId = Guid.Parse("02FEAA5F-590F-41C4-8151-C5EBE01B0EBA")},
    //     };
    //     
    //     dbContext.Answers.AddRange(res);
    //     dbContext.SaveChanges();
    //     
    //     return "Ok";
    // }

    // public static string AddTerms(FirstCusrHelpAppContext dbContext)
    // {
    //     var res = new List<Term>()
    //     {
    //         new Term{ Id = Guid.NewGuid(), Word = "Втокус", Explanation = "Студент второго курса."},
    //         new Term{ Id = Guid.NewGuid(), Word = "Пекус", Explanation = "Студент первого  курса. Также встречается синоним: первак."},
    //         new Term{ Id = Guid.NewGuid(), Word = "Трекус", Explanation = "Студент третьего курса."},
    //         new Term{ Id = Guid.NewGuid(), Word = "Фокус", Explanation = "Студент четвёртого курса."},
    //         new Term{ Id = Guid.NewGuid(), Word = "Большак", Explanation = "Перерыв между 3-ей и 4-ой  парами. Является самым  длинным из всех  перерывов. Многие студенты предпочитают перекусить именно  во время него."},
    //         new Term{ Id = Guid.NewGuid(), Word = "Модеус", Explanation = "Платформа, реализующая ИОТ, через предметную выборную кампанию."},
    //         new Term{ Id = Guid.NewGuid(), Word = "Индивидуальная образовательная траектория(ИОТ)", Explanation = "Способ организации учебного процесса, позволяющего студентам определять обучающие курсы и мастерские внутри курса."},
    //         new Term{ Id = Guid.NewGuid(), Word = "Социалка", Explanation = "Социальная стипендия, предаставляемая приезжим студентам с малым доходом."}
    //     };
    //     
    //     dbContext.Terms.AddRange(res);
    //     dbContext.SaveChanges();
    //     
    //     return "Ok";
    // }
}