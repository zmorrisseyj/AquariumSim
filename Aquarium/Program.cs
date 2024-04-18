


using Aquarium.Fish;

var firstFish = new Fish("Bubbles", "first test fish he's like a little guy", 10, 20, Aquarium.Color.White, 0,0,5,0);
firstFish.DisplayInfo();
firstFish.Swim(1);
firstFish.DisplayInfo();
firstFish.Eat(2);
firstFish.DisplayInfo();
firstFish.Poop();
firstFish.DisplayInfo();

Console.ReadLine();
