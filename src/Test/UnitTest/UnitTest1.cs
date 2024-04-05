using CMSRepository;
using Core;
using Core.Abstract;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var componentBuilder = new CatCMSComponentBuilder() as ICatCMSComponentBuilder;

            var component = componentBuilder.CreateCarousel() as BaseCatComponent;

            component.AddComponents(new BaseCatComponent[]
            {
                new CarouselCatComponent()
            });

            var userRepository = new UserRepository();

            try
            {
                var user = userRepository.Find(new { Id = 1 });


            }
            catch (EntityNotFoundException)
            {
                throw;
            }

            
           
        }
    }
}