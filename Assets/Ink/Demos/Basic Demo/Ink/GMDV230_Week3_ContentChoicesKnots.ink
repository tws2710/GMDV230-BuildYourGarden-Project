VAR attitude = ""
VAR garden_choice = ""
VAR garden_detail = ""

-> mystery_intro

=== mystery_intro ===
You step into your backyard early in the morning and the sun just peeking over the fence.

But something’s off.

You walk over to your tomato plant and notice one of the biggest tomatoes you were planning to pick is gone.

You look around the garden to see if you can figure out what happened.

* Check around the tomato plant for clues. -> investigate_scene
* Ignore it and get on with gardening. -> garden_intro

=== investigate_scene ===
You kneel by the plant and notice the soil’s a bit messy. There are tiny tracks leading away.

Hmm. What could’ve done this?

* Probably a squirrel. They’re always running along the fence.
    ~ attitude = "cautious"
    -> suspect_squirrel
* Maybe the neighbor’s dog that likes to dig around.
    ~ attitude = "practical"
    -> suspect_pet
* Maybe it just fell off and rolled somewhere.
    ~ attitude = "playful"
    -> suspect_natural

=== suspect_squirrel ===
You decide to set up a little motion camera overnight, just to see what’s going on.

Sure enough, the next morning you catch a squirrel on camera running off with another tomato.

Guess it’s time to set up some netting around the plant.

-> garden_intro

=== suspect_pet ===
You ask your neighbor if their dog has been out and about lately.

They admit she sneaks around sometimes and digs for fun. #dog_bark

Time to set up a small fence around your garden.

-> garden_intro

=== suspect_natural ===
You check around some bushes nearby and find your tomato. It is kinda squished and probably rolled off in the wind.

At least no one stole it. Still, now you want to grow even more.

-> garden_intro

=== garden_intro ===

With the mystery sort of solved, you turn your attention to the fun part.

Today’s the day. You’re finally starting your garden for real after having so much fun experimenting with tomatoes. The yard's open and waiting to grow something awesome.

What kind of garden do you want to build?

* A veggie garden for fresh stuff I can eat.
    ~ garden_choice = "veggie"
    ~ attitude = ""
    -> veggie_start
* A flower garden for the cool colors and good vibes.
    ~ garden_choice = "flower"
    ~ attitude = ""
    -> flower_start
* A succulent setup that is low maintenance and good for beginners.
    ~ garden_choice = "succulent"
    ~ attitude = ""
    -> succulent_start

=== veggie_start ===
You decide to go with vegetables. You grab your tools and start sketching out where everything will go.

What should go in first?

* Tomatoes. They turned out good on your initial attempt. 
    ~ garden_detail = "tomatoes"
    -> plant_tomatoes
* Lettuce. Quick and easy greens sound great. 
    ~ garden_detail = "lettuce"
    -> plant_lettuce

=== plant_tomatoes ===
You plant some tomato seedlings and give them some water. They love the sun, so you make sure they’re in the best spot.

A few weeks go by and you start seeing little green tomatoes. But… the leaves have some spots.

* Look up a fix and try to treat them. -> treat_tomatoes
* See if the plant can handle it on its own. -> ignore_tomatoes

=== treat_tomatoes ===
You get some neem plant spray, trim the bad leaves, and check on them every day.

It works and by the end of summer, you’re picking big, juicy tomatoes. Enjoy!

-> END

=== ignore_tomatoes ===
Turns out those spots were bad news and the plant slowly droops and shrivels up.

Next time, you’ll jump on that faster.

-> END

=== plant_lettuce ===
Lettuce grows super fast, and after a couple of weeks, you’ve got little leafy sprouts popping up.

Then you notice a sneaky rabbit eating your lettuce.

* Put up a fence to keep it out. -> fence_rabbit
* Let it nibble since you want to help the rabbit. -> share_with_rabbit

=== fence_rabbit ===
You build a little fence around the lettuce patch and it works like a charm.

The rabbit moves on, and you get to enjoy your homegrown greens.

-> END

=== share_with_rabbit ===
You decide to let the rabbit snack a little. The lettuce never really grows big, but you don’t mind.

You enjoy having a little garden buddy.

-> END

=== flower_start ===
You head to the garden center and grab a bunch of bright, cheerful flowers.

Where should they go?

* In neat little rows by the fence. 
    ~ garden_detail = "fence_flowers"
    -> fence_flowers
* Just scatter them around and let them do their thing. 
    ~ garden_detail = "wild_flowers"
    -> wild_flowers

=== fence_flowers ===
You line up the tulips and lilies in clean rows.

Your neighbors are impressed when they see your garden which feels good.

-> END

=== wild_flowers ===
You go all in and plant the flowers everywhere with no pattern.

You enjoy the random nature vibe it brings with different colors everywhere.

-> END

=== succulent_start ===
Succulents are easy and cool looking, so you grab a few little pots and some soil.

Now to pick your main plant.

* Aloe vera since it is useful. 
    ~ garden_detail = "aloe"
    -> aloe_choice
* A mix of colorful echeveria. 
    ~ garden_detail = "echeveria"
    -> echeveria_choice

=== aloe_choice ===
You place the aloe by the window and it starts thriving. Later, you get a sunburn and remember you’ve got aloe right there.

It ended up being more than just a nice decoration.

-> END

=== echeveria_choice ===
You arrange the echeveria in a cute little pattern and post a picture to your social media.

Your friends love it and ask if you can design them an arrangement.

-> END