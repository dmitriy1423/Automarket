using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.Context
{
    public class SeedData
    {
        public static void SeedDatabase(AppDbContext context)
        {
            context.Database.Migrate();

            if (!context.Cars.Any())
            {
                Category sedans = new Category { Name = "Седан", Slug = "sedans" };
                Category hatchbacks = new Category { Name = "Хэтчбек", Slug = "hatchbacks" };
                Category miniven = new Category { Name = "Минивэн", Slug = "miniven" };
                Category sport = new Category { Name = "Спортивная машина", Slug = "sport" };
                Category suv = new Category { Name = "Внедорожник", Slug = "suv" };

                context.Cars.AddRange(
                        new Car
                        {
                            Name = "Lada Granta Sport",
                            Slug = "lada-granta-sport",
                            Description = "Седан с приставкой «Sport», в отличие о предыдущих автомобилей «Lada» отмеченных этим шильдиком – не ограничивается «декором», а действительно получил «более спортивную техническую составляющую» (включая достаточно эластичный 118-сильный мотор).",
                            Speed = 190,
                            Price = 1249900,
                            Category = sedans,
                            Image = "granta-sport-sedan.webp",
                            CountSales = 3,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Lada Vesta",
                            Slug = "lada-vesta",
                            Description = "Кросс-трёхобъёмник в концептуальном обличье был явлен миру в августе 2016 года в Москве, а в апреле 2018-го там же был представлен серийный образец. Он «щеголяет»: вседорожным декором снаружи и яркими вставками в салоне, а технически повторяет стандартную модель.",
                            Speed = 180,
                            Price = 763900,
                            Category = sedans,
                            Image = "vesta-sedan-cross.jpg",
                            CountSales = 4,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Honda Accord",
                            Slug = "honda-accord",
                            Description = "Accord – переднеприводный седан среднеразмерного сегмента, который в самой компании Honda Motor позиционируют не иначе, как «настоящим эталоном в своем классе, отличающимся непревзойденной комбинацией стиля, производительности, экономичности и возможностей подключения гаджетов».",
                            Speed = 240,
                            Price = 1650000,
                            Category = sedans,
                            Image = "accord-11-tmb.jpg",
                            CountSales = 2,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Honda Legend V",
                            Slug = "honda-legend-v",
                            Description = "Будучи представленным в ноябре 2014 года и выйдя на японский рынок в феврале 2015-го, пятое поколение флагманского седана Honda – «Legend», стало, по сути, «адаптированной под местные стандарты» версией премиального седана Acura RLX Sport Hybrid (уже доступного на тот  момент в США).",
                            Speed = 200,
                            Price = 5210000,
                            Category = sedans,
                            Image = "legend-5-tmb.jpg",
                            CountSales = 2,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Lexus CT200h",
                            Slug = "lexus-ct200h",
                            Description = "Этот премиум-хэтч вышел на рынок в 2010 году, а в 2013-м пережил своевременное обновление. Автомобиль, первым среди «одноклассников» получивший гибридную силовую установку, имеет в своем арсенале оригинальную внешность, премиальный интерьер и богатое оснащение.",
                            Speed = 180,
                            Price = 2620000,
                            Category = hatchbacks,
                            Image = "CT-200h.jpg",
                            CountSales = 5,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Infiniti Q30",
                            Slug = "infiniti-q30",
                            Description = "«Оспортивленный» вариант машины с приставкой «Sport» дебютировал одновременно с базовой моделью, от которой он отличается агрессивными акцентами во внешности и интерьере и более жесткой подвеской. Такая пятидверка доступна только с самым мощным мотором и полным приводом.",
                            Speed = 228,
                            Price = 2445900,
                            Category = hatchbacks,
                            Image = "Q30S.jpg",
                            CountSales = 3,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Audi A3 Sportback",
                            Slug = "audi-a3-sportback",
                            Description = "Премиум-хэтч четвёртой генерации представили к началу весны 2020 года в Женеве (а если быть точнее – то в глобальной сети). Это – эмоциональный внешне автомобиль, обладающий «породистым» салоном, производительной техникой и богатым оснащением.",
                            Speed = 250,
                            Price = 2778000,
                            Category = hatchbacks,
                            Image = "a3-tmb.jpg",
                            CountSales = 4,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Ford Focus IV",
                            Slug = "ford-focus-4",
                            Description = "Ford Focus – переднеприводный пятидверный хэтчбек «гольф»-класса по европейским меркам, имеющий «глобальное позиционирование», который может похвастать привлекательным дизайном, всеми положительными качествами, присущими «семейным автомобилям», а также драйверским характером",
                            Speed = 220,
                            Price = 2200000,
                            Category = hatchbacks,
                            Image = "Focus-4-hatch.jpg",
                            CountSales = 3,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Ford Galaxy 3",
                            Slug = "ford-galaxy-3",
                            Description = "Полноразмерный вэн третьей генерации встал на конвейер в 2006 году, а покинул его в 2014-м (предварительно обновившись в 2010 году). Семейный «американец» имеет в своем активе солидный вид, просторный семиместный салон и мощные моторы в подкапотном пространстве.",
                            Speed = 193,
                            Price = 1100000,
                            Category = miniven,
                            Image = "galaxy-3.jpg",
                            CountSales = 6,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Citroen C8",
                            Slug = "citroen-c8",
                            Description = "Автомобиль Citroen C8 производится с 2002 г., а в России появился в продаже с 2003-го. В своем сегменте Citroen C8 – ветеран. Выпускается он на той же платформе и на том же заводе, что и Peugeot 807, и Lancia Phedra: все три модели разрабатывались совместными усилиями концернов FIAT и Peugeot-Citroen.",
                            Speed = 185,
                            Price = 1900000,
                            Category = miniven,
                            Image = "citroen-c8.jpg",
                            CountSales = 5,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Renault Grand Scenic 3",
                            Slug = "renault-grand-scenic-3",
                            Description = "В 2012 году на российский рынок пришел обновленный Scenic 3-го поколения. Однако нас, в этом обзоре, будет интересовать его семиместная модификация – «Grand Scenic». Этот обновленный красавец, завоевавший громадную популярность в Европе, поступил на европейский авторынок в начале 2012 года.",
                            Speed = 190,
                            Price = 2000000,
                            Category = miniven,
                            Image = "renault-grand-scenic-2013.jpg",
                            CountSales = 2,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Toyota Sienna",
                            Slug = "toyota-sienna",
                            Description = "Полноприводный «большой минивэн» (ориентированный, в первую очередь, на североамериканский рынок), который сочетает в себе: солидный внешний дизайн, качественный и вместительный салон, высокий уровень универсальности, а также мощную техническую «начинку»… Автомобиль адресован семейным людям, имеющим несколько детей, которые любят дальние путешествия",
                            Speed = 180,
                            Price = 2100000,
                            Category = miniven,
                            Image = "Sienna-XL30.jpg",
                            CountSales = 3,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Toyota Supra",
                            Slug = "toyota-supra",
                            Description = "Заднеприводный спортивный автомобиль класса «Grand Tourer», который ведет свою историю с 1978 года. Но изначально он являлся всего-навсего одной из модификаций модели «Celica», самостоятельность же эта машина обрела лишь в 1986-м… а «жизненный цикл» продолжала до 2002 года – именно тогда двухдверка покинула конвейер… но в 2019 году эту модель «торжественно воскресили».",
                            Speed = 250,
                            Price = 5500000,
                            Category = sport,
                            Image = "Supra-A90.jpg",
                            CountSales = 2,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Lexus LC500",
                            Slug = "lexus-lc500",
                            Description = "Lexus LC 500 Convertible – заднеприводный полноразмерный премиум-кабриолет, который воплощает в себе (по крайней мере, со слов самого японского автопроизводителя) «исключительную японскую эстетику с невероятно чувственными, ни с чем несравнимыми эмоциями от вождения»… Основная целевая аудитория двухдверки – очень состоятельные люди (вне зависимости от пола), которые любят «выделяться из толпы», демонстрируя свою финансовую успешность",
                            Speed = 280,
                            Price = 8900000,
                            Category = sport,
                            Image = "LC500C-front.jpg",
                            CountSales = 0,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Mazda MX-5",
                            Slug = "mazda-mx-5",
                            Description = "На автосалоне в Нью-Йорке, распахнувшем двери для посетителей в конце марта 2016 года, японская марка Mazda публично представила новую модификацию модели MX-5 четвертой генерации под названием RF (Retractable Fastback), которое указывает на наличие у двухдверки жесткой складной крыши.",
                            Speed = 240,
                            Price = 2400000,
                            Category = sport,
                            Image = "MX-5-RF.jpg",
                            CountSales = 2,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Ferrari 488",
                            Slug = "ferrari-488",
                            Description = "Заднеприводный среднемоторный суперкар премиум-класса, который предлагается в двух кузовных исполнениях: купе и родстер со складной жесткой крышей… Автомобиль сочетает в себе: элегантный дизайн, высокопроизводительную техническую «начинку» и отменные «ходовые» характеристики",
                            Speed = 340,
                            Price = 22000000,
                            Category = sport,
                            Image = "488-Pista.jpg",
                            CountSales = 1,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Toyota LC Prado 5",
                            Slug = "toyota-lc-prado-5",
                            Description = "Классический внедорожник полноразмерного класса с рамным кузовом, неразрезным задним мостом и полным приводом, сочетающий в себе брутальный дизайн, современный и вместительный салон, в меру производительную техническую «начинку» и хороший внедорожный потенциал.",
                            Speed = 175,
                            Price = 5300000,
                            Category = suv,
                            Image = "tlc250-tmbold.jpg",
                            CountSales = 2,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Mazda BT-50",
                            Slug = "mazda-bt-50",
                            Description = "Среднеразмерный «грузовичок» третьего поколения дебютировал 17 июня 2020 года в ходе онлайн-презентации. Он может похвастать привлекательным дизайном, однако в техническом плане практически целиком и полностью повторяет «третий» Isuzu D-Max.",
                            Speed = 158,
                            Price = 900000,
                            Category = suv,
                            Image = "bt50-3-tmb.jpg",
                            CountSales = 0,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Volvo XC90",
                            Slug = "volvo-xc90",
                            Description = "Это «классика» – добротный шведский среднеразмерный внедорожник… он настолько добротный, надежный и безопасный, что продержался на конвейере 12 (!!!) лет (конечно же, подвергаясь незначительным обновлениям, но в целом «оставаясь самим собой»)",
                            Speed = 200,
                            Price = 3400000,
                            Category = suv,
                            Image = "xc90-1-tmb.jpg",
                            CountSales = 3,
                            IsDeleted = false,
                        },
                        new Car
                        {
                            Name = "Cadillac Escalade 5",
                            Slug = "cadillac-escalade-5",
                            Description = "Полноразмерный рамный премиум-внедорожник пятой генерации официально дебютировал 4 февраля 2020 года в Калифорнии. Он может похвастать брутальным дизайном, современным и роскошным салоном, а также производительной технической «начинкой»",
                            Speed = 180,
                            Price = 9200000,
                            Category = suv,
                            Image = "escalade-5.jpg",
                            CountSales = 0,
                            IsDeleted = false,
                        }
                );

                context.SaveChanges();
            }
        }
    }
}
