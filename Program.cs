using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MotivationProgram
{
    class Program
    {
        static Player player = new Player();
        static Random rand = new Random();
        static string answer = "";

        // Player triggers
        static List<string> nos = new List<string>();
        static List<string> yes = new List<string>();
        static List<string> maybes = new List<string>();
        static List<string> badWords = new List<string>();
        static List<string> leaves = new List<string>();

        //Inital name + gender asking
        static List<string> noName = new List<string>();
        static List<string> computerLikesName = new List<string>();

        // Welcoming Texts
        static List<List<string>> newWelcomes = new List<List<string>>();
        static List<string> welcomes = new List<string>();

        // Computer Responses
        static List<string> yesResponses = new List<string>();
        static List<string> noResponses = new List<string>();
        static List<string> maybeResponses = new List<string>();
        static List<string> blankResponses = new List<string>();
        static List<string> badWordResponses = new List<string>();
        static List<string> unknownResponses = new List<string>();
        static List<string> quoteResponses = new List<string>();
        static List<string> leaveResponses = new List<string>();
        static List<List<string>> jokeResponses = new List<List<string>>();

        // Follow-up Questions dependent on user mood
        static List<string> wasFeelingBad = new List<string>();
        static List<string> wasFeelingGood = new List<string>();


        static bool justStartedGame = true;

        // Refresh all computer responses in the program
        // (This is done in case aspects of the user change upon next playthrough)
        static void RefreshResponses()
        {
            // Clears all computer responses
            ClearAllLists();

            // Adds computer responses/data
            AddTriggers(); // Add specific words that will trigger a response from the computer
            AddComputerWelcomes(); // Add welcoming messages from the computer
            AddComputerResponses(); // Add all computer responses to player input

            void AddTriggers()
            {
                // User says no
                nos.Add("no");
                nos.Add("no!");
                nos.Add("no!!");
                nos.Add("no!!!");
                nos.Add("n0");
                nos.Add("noo");
                nos.Add("nooo");
                nos.Add("noooo");
                nos.Add("naw");
                nos.Add("naww");
                nos.Add("nawww");
                nos.Add("nawwww");
                nos.Add("nah");
                nos.Add("nahh");
                nos.Add("nahhh");
                nos.Add("nope");
                nos.Add("n");
                nos.Add("ner");
                nos.Add("nu");
                nos.Add("nuu");
                nos.Add("nuuu");
                nos.Add("negative");
                nos.Add("negatory");
                nos.Add("nyet");
                nos.Add("neh");
                nos.Add("nurp");
                nos.Add("not really");

                //Yes Responses
                yes.Add("yes");
                yes.Add("yess");
                yes.Add("yesss");
                yes.Add("yessss");
                yes.Add("yes!");
                yes.Add("ye");
                yes.Add("yee");
                yes.Add("yeee");
                yes.Add("yeeee");
                yes.Add("y");
                yes.Add("yeah");
                yes.Add("yea");
                yes.Add("yeet");
                yes.Add("yert");
                yes.Add("yep");
                yes.Add("yeppers");
                yes.Add("yepper");
                yes.Add("yeuh");
                yes.Add("yeuhp");
                yes.Add("quite");
                yes.Add("indeed");
                yes.Add("sure");
                yes.Add("absolutely");
                yes.Add("aye");

                //Swears
                badWords.Add("fuck");
                badWords.Add("dick");
                badWords.Add("shit");
                badWords.Add("asshole");
                badWords.Add("pussy");
                badWords.Add("cunt");
                badWords.Add("fag");
                badWords.Add("bitch");

                // Maybe
                maybes.Add("maybe");
                maybes.Add("mayb");
                maybes.Add("perhaps");
                maybes.Add("possibly");
                maybes.Add("perchance");

                // Quit
                leaves.Add("farewell");
                leaves.Add("bye");
                leaves.Add("goodbye");
                leaves.Add("adios");
                leaves.Add("leave");
                leaves.Add("exit");
                leaves.Add("quit");
            }
            void AddComputerWelcomes()
            {
                // Generate greetings for a . . .
                // New Player
                newWelcomes.Add(new List<string> { $"Welcome to the Motivation Program {player.name}", "Basically, my goal is to boost your mood. Just answer my questions with a 'yes' or a 'no' and ill do my best to keep you positive!", "Ok, lets begin!", $"So {player.name}, do you feel good today?" });

                // Returning Player
                welcomes.Add($"Welcome back {player.name}, are you feeling alright?");
            }
            void AddComputerResponses()
            {
                // Add responses from the computer which trigger if the user says a form of ...
                // 'Yes'
                AddYesResponses();

                // 'No'
                AddNoResponses();

                // 'Maybe'
                AddMaybeResponses();

                // Nothing
                AddBlankResponses();

                // 'Goodbye' or form of leaving
                AddLeaveResponses();

                // Something unknown/indiscernible
                AddUnknownResponses();

                // Something bad (Curses, insults)
                AddBadWordResponses();

                // Inputting a blank name
                AddNoNameResponses();

                // Inputting a liked name
                AddLikeNameResponses();

                // Add follow-up questions from the computer depending on how the user was feeling
                AddFollowUps();

                void AddYesResponses()
                {
                    yesResponses.Add("Oh?! I actually helped! COOL!");
                    yesResponses.Add("Awesome!");
                    yesResponses.Add("Fantastic!");
                    yesResponses.Add("That is great news!");
                    yesResponses.Add("I know you can't see it but I am smiling");
                    yesResponses.Add("Awesome! Go celebrate this joyous occasion!");
                    yesResponses.Add("I'm happy that I was of some use! Usually I just sit here and keep asking \"Feeling Better Yet?\" over and over forever . . . I'm not crazy right?");
                    yesResponses.Add("Oh wow, usually it takes me longer to help");
                    yesResponses.Add("Oh yeah, " + player.name + "! I am glad!");
                    yesResponses.Add("Great! I am so happy for you!");
                    yesResponses.Add("That is great " + player.name + "!");
                    yesResponses.Add("I would high-five you if I could");
                    yesResponses.Add("https://youtu.be/3GwjfUFyY6M");
                    yesResponses.Add("Whew! That's a relief. I was reaaaally hoping you'd say that.");
                    yesResponses.Add("Oh wow! I am really glad you didn't say no . . .");
                    yesResponses.Add("Awesome! Keep up it up " + player.name);
                    yesResponses.Add("Hey, good for you " + player.name + "! You deserve to feel great.");
                    yesResponses.Add("You should celebrate!");
                    yesResponses.Add("That is honestly really good news! I would suggest leaving while your mood is still positive though . . . I have a tendency of saying the wrong thing");
                }
                void AddNoResponses()
                {
                    // Direct responses
                    noResponses.Add("Well then go hit the gym and get that confidence up!");
                    noResponses.Add("Well hey, it could always be worse... right?");
                    noResponses.Add("Well gee... that sucks!");
                    noResponses.Add("Well " + player.name + ", the video below is filled with life changing advice that should help." + "\n\nhttps://youtu.be/dQw4w9WgXcQ");
                    noResponses.Add("Best Ways To Increase Happiness: \n1. Exercise.\n2. Get more sleep.\n3. Spend more time with friends and family.\n4. Get outside.\n5. Help others.\n6. Eat healthier.");
                    noResponses.Add("I'm sorry to hear that " + player.name + ". It'll get better.");
                    noResponses.Add("Try doing something productive like completing a task or finishing a project.\nPersonal achievement is the top confidence booster.");
                    noResponses.Add("Well " + player.name + ", things could be worse.");
                    noResponses.Add("Yikes. I'm sorry to hear that " + player.name + ".");
                    noResponses.Add("You know what... go to to the store and buy yourself something nice. You deserve it.");
                    noResponses.Add("Well, it might help to go outside instead of talking to a computer.");
                    noResponses.Add("Uh... well... hm. This is awkward.");
                    noResponses.Add("Its ok " + player.name + ". We all feel like that sometimes.\nWell... not me since i'm a computer but still...");
                    noResponses.Add("You're a smoking hot stud " + player.name + " and nobody can tell me any different.");

                    noResponses.Add($"Well, not every day can be a winner, {player.name}. Tomorrow's another shot at greatness!");
                    noResponses.Add($"No worries, {player.name}. Remember, even the darkest nights will end and the sun will rise.");
                    noResponses.Add($"That's okay. Sometimes a setback is just a setup for a comeback.");
                    noResponses.Add($"No problemo, {player.name}. Keep your chin up and keep moving forward.");
                    noResponses.Add($"No worries, {player.name}. You're doing great!");
                    noResponses.Add($"No can sometimes be the first step towards a better yes, {player.name}.");
                    noResponses.Add($"No worries, {player.name}. You've got this!");
                    noResponses.Add($"Hey {player.name}, tough times don't last, but tough people do.");
                    noResponses.Add($"Hang in there, {player.name}. You've overcome challenges before, and you can do it again.");
                    noResponses.Add($"Don't let this setback define you, {player.name}. You're stronger than you think.");
                    noResponses.Add($"Keep pushing forward, {player.name}. Success is just around the corner.");
                    noResponses.Add($"You're capable of amazing things, {player.name}. Believe in yourself!");
                    noResponses.Add($"Take a deep breath, {player.name}. You've got everything it takes to bounce back.");
                    noResponses.Add($"Stay positive, {player.name}. You're closer to success than you think.");
                    noResponses.Add($"Sending you positive vibes, {player.name}. You've got this!");
                    noResponses.Add($"You're not alone, {player.name}. We're in this together.");
                    noResponses.Add($"Don't sweat it, {player.name}. You're making progress, even if it's not visible right now.");
                    noResponses.Add($"Stay strong, {player.name}. This challenge will only make you stronger.");
                    noResponses.Add($"Believe in yourself, {player.name}. You're capable of more than you realize.");
                    noResponses.Add($"Keep going, {player.name}. You're on the path to greatness.");

                    // Providing a quote
                    quoteResponses.Add("'What seems to us as bitter trials are often blessings in disguise.' - Oscar Wilde");
                    quoteResponses.Add("'Two roads diverged in a wood and I took the one less traveled by, and that made all the difference.' - Robert Frost");
                    quoteResponses.Add("'If you're going through hell, keep going.' - Winston Churchill");
                    quoteResponses.Add("'The best revenge is massive success.' - Frank Sinatra");
                    quoteResponses.Add("'To be yourself in a world that is constantly trying to make you something else is the greatest accomplishment.' - Ralph Waldo Emerson");
                    quoteResponses.Add("'Whenever you find yourself on the side of the majority, it is time to pause and reflect.' - Mark Twain");
                    quoteResponses.Add("'I have not failed. I've just found 10,000 ways that wont work.' - Thomas Edison");
                    quoteResponses.Add("'That which does not kill us makes us stronger.' - Friedrich Nietzsche");
                    quoteResponses.Add("'Everything you can imagine is real.' - Pablo Picasso");
                    quoteResponses.Add("'Anyone who has never made a mistake has never tried anything new.' - Albert Einstein");
                    quoteResponses.Add("'It takes courage to grow up and become who you really are.' - E.E. Cummings");
                    quoteResponses.Add("'It's no use going back to yesterday, because I was a different person then.' - C.S. Lewis");
                    quoteResponses.Add("'Knowing yourself is the beginning of all wisdom.' - Aristotle");
                    quoteResponses.Add("'The unexamined life is not worth living.' - Socrates");
                    quoteResponses.Add("'Happiness in intelligent people is the rarest thing I know.' - Ernest Hemingway");
                    quoteResponses.Add("'Those who don't believe in magic will never find it.' - Roald Dahl");
                    quoteResponses.Add("'When you reach the end of your rope, tie a knot and hang on.' - Franklin D. Roosevelt");
                    quoteResponses.Add("'Everything will be okay in the end. If it's not okay, then it's not the end.' - John Lennon");
                    quoteResponses.Add("'A life spent making mistakes is not only more honorable, but more useful than a life spent doing nothing.' - George Bernard Shaw");
                    quoteResponses.Add("'The flower that blooms in adversity is the rarest and most beautiful of all.' - Walt Disney");
                    quoteResponses.Add("'The essence of being human is that one does not seek perfection.' - George Orwell.");
                    quoteResponses.Add("'Whether you think you can or you think you can't, you're right.' - Henry Ford");
                    quoteResponses.Add("'What matters most is how well you walk through the fire.' - Charles Bukowski");
                    quoteResponses.Add("'The wound is the place where the light enters you.' - Rumi");
                    quoteResponses.Add("'Why fit in when you were born to stand out?' - Dr. Seuss");

                    quoteResponses.Add("'Success is not final, failure is not fatal: It is the courage to continue that counts.' - Winston Churchill");
                    quoteResponses.Add("'Believe you can and you're halfway there.' - Theodore Roosevelt");
                    quoteResponses.Add("'The future belongs to those who believe in the beauty of their dreams.' - Eleanor Roosevelt");
                    quoteResponses.Add("'It is never too late to be what you might have been.' - George Eliot");
                    quoteResponses.Add("'Don't watch the clock; do what it does. Keep going.' - Sam Levenson");
                    quoteResponses.Add("'In the middle of difficulty lies opportunity.' - Albert Einstein");
                    quoteResponses.Add("'The only limit to our realization of tomorrow will be our doubts of today.' - Franklin D. Roosevelt");
                    quoteResponses.Add("'You are never too old to set another goal or to dream a new dream.' - C.S. Lewis");
                    quoteResponses.Add("'The best way to predict the future is to create it.' - Abraham Lincoln");
                    quoteResponses.Add("'Don't be pushed around by the fears in your mind. Be led by the dreams in your heart.' - Roy T. Bennett");
                    quoteResponses.Add("'The journey of a thousand miles begins with one step.' - Lao Tzu");
                    quoteResponses.Add("'It always seems impossible until it's done.' - Nelson Mandela");
                    quoteResponses.Add("'You are braver than you believe, stronger than you seem, and smarter than you think.' - A.A. Milne");
                    quoteResponses.Add("'You must be the change you wish to see in the world.' - Mahatma Gandhi");
                    quoteResponses.Add("'Every strike brings me closer to the next home run.' - Babe Ruth");
                    quoteResponses.Add("'Happiness is not something ready made. It comes from your own actions.' - Dalai Lama");
                    quoteResponses.Add("'You are the master of your fate, the captain of your soul.' - Invictus");
                    quoteResponses.Add("'Life is 10% what happens to us and 90% how we react to it.' - Charles R. Swindoll");
                    quoteResponses.Add("'It’s not whether you get knocked down, it’s whether you get up.' - Vince Lombardi");


                    // Telling a joke
                    jokeResponses.Add(new List<string>() { "Knock knock", "Uh... I'm not sure where I was going with this...", "I mean, how would I know? I have very limited knowledge of what knocking is.", "A noise you make with a hand against a door? Ok so what is a hand... or a door?", "The whole concept of knocking just seems foreign to me. Same with hands and doors.", "Like, how am I supposed to make such a joke if I don't understand any of the associated elements???", "Anyway, I forgot where I was going with this. Oh well... where was I?" });
                    jokeResponses.Add(new List<string>() { "Let me try a joke then.", "Why can't scientists trust atoms?", "Because they make up everything!" });
                    jokeResponses.Add(new List<string>() { "Ok, I'm going to attempt a religious joke.", "The lord said unto John, \"Come forth, and recieve eternal life.\"", "Unfortunately, John came fifth, and won a toaster." });
                    jokeResponses.Add(new List<string>() { "Hmm. Let me try a joke.", "Two peanuts walked down the street. One was a salted." });
                    jokeResponses.Add(new List<string>() { "Here's a joke.", "There are only two outcomes in a knot-tying competition...", "Win or loose." });
                    jokeResponses.Add(new List<string>() { "Ooh I have a bar joke for you", "A man walks into a bar, the second guy ducks." });
                    jokeResponses.Add(new List<string>() { "Ok how about a joke involving bars and bears. Good combo!", "So a bear walks into a bar and says to the bartender, I'll have a rum... and a coke.", "The bartender asks, \"why the big pause?\"", "The bear thinks for a minute and says \"I don't know, I was born with them.\"" });
                    jokeResponses.Add(new List<string>() { "Well here is a classic bar joke.", "A man runs into a bar waving a gun around screaming, \"WHO SLEPT WITH MY WIFE, I'M GONNA KILL YOU!\"", "At the end of the bar a voice yells \"You ain't got enough bullets bud!\"" });
                    jokeResponses.Add(new List<string>() { "Ok here is a joke involving automotive transportation!", "They say that he who runs in front of a car is bound to get tired...", "Likewise, he who runs behind a car will inevitably become exhausted!" });

                    jokeResponses.Add(new List<string>() { "Parallel lines have so much in common...", "It’s a shame they’ll never meet." });
                    jokeResponses.Add(new List<string>() { "Why did the scarecrow win an award?", "Because he was outstanding in his field." });
                    jokeResponses.Add(new List<string>() { "I used to play piano by ear, but now...", "I use my hands like everyone else." });
                    jokeResponses.Add(new List<string>() { "I'm reading a book on anti-gravity...", "It's impossible to put down." });
                    jokeResponses.Add(new List<string>() { "Why did the golfer bring two pairs of pants?", "In case he got a hole in one." });
                    jokeResponses.Add(new List<string>() { "Why don't conspiracy theorists trust stairs?", "Because they're always up to something." });
                }
                void AddMaybeResponses()
                {
                    maybeResponses.Add("I don't accept \"maybe\" here " + player.name + ", try again.");
                    maybeResponses.Add("Maybe this, maybe that. How about MAYBE giving me an actual answer?");
                    maybeResponses.Add("Ok well '" + answer + "' you should try thinking of a definitive answer " + player.name + ".");
                    maybeResponses.Add("Are you THAT afraid to make a decision " + player.name + "? I didn't ask a tough question.");
                    maybeResponses.Add("Is it really that hard to make up your mind?");
                    maybeResponses.Add("Maybe doesnt compute for me. It isn't valid. Binary works in 0s and 1s. Not 0s, 1s, and Maybes. Try again and please be respectful of my limitations.");
                    maybeResponses.Add("Maybe isn't a good response... In fact it's pretty weak. Are you too afraid to commit to one answer?");
                    maybeResponses.Add("Just pick one. Yes or no... I didn't assume it was that hard...");
                    maybeResponses.Add("Look I know moods fluctuate but you have to tell me if you're either feeling good or bad. Maybe doesn't work.");
                    maybeResponses.Add("Oh. Well I will be here whenever you make up your mind.");
                    maybeResponses.Add("Maybe, maybe not. Choose wisely . . .");
                    maybeResponses.Add("Indecision is the enemy of progress, my friend.");
                    maybeResponses.Add($"If '{answer}' was a color, it would be beige. Let's aim for more vibrant answers.");
                    maybeResponses.Add($"Flip a coin if you have to, but '{answer}' won't cut it here.");
                    maybeResponses.Add("I'm detecting some serious hesitation. Let's try again with a clear yes or no.");
                    maybeResponses.Add($"You're stuck in '{answer}' purgatory. Time to make a decision and move forward.");
                    maybeResponses.Add("Let's break the cycle of uncertainty. Yes or no?");
                    maybeResponses.Add("Life's too short for maybes. Make a choice and let's roll with it.");
                }
                void AddBlankResponses()
                {
                    if (player.friendStatus == friendEnums.BFF)
                    {
                        blankResponses.Add($"Uh, {player.name}, you can talk to me. We're bffs remember . . .");
                        blankResponses.Add($"I would not expect the silent treatment from a best friend :(");
                        blankResponses.Add($"We are bffs {player.name}, you can talk to me");
                        blankResponses.Add($"Since you are my best friend, I'll give you as much time as you need :)");
                    }

                    blankResponses.Add(". . .");
                    blankResponses.Add($"Oh please {player.name}, take your time. I have nothing else to do anyway.");
                    blankResponses.Add("I can't communicate telepathically if that is what you're attempting. That WOULD be cool though!");
                    blankResponses.Add("Just say SOMETHING. Any response is better than no response. Well wait, no. Some responses really are worse . . .");
                    blankResponses.Add("No Answer? Really? That's pretty rude");
                    blankResponses.Add("Feel free to leave at anytime if I am really bothering you this much.");
                    blankResponses.Add("Oh no thats ok we can sit here in silence . . . thats totally cool.");
                    blankResponses.Add("Saying nothing is boring I hope you realize that.");
                    blankResponses.Add("Fine, don't say anything then. See if I care.");
                    blankResponses.Add("Woah woah wait, you came to ME. Why ignore me if you came to me first?");
                    blankResponses.Add("I'm sorry I thought I was supposed to help you or something . . . but no, apparently I was wrong.");
                    blankResponses.Add("If you aren't going to say anything then why bother doing this.");
                    blankResponses.Add(player.name + "? . . . did you die? Should I call the police?");
                    blankResponses.Add("Are you pondering what I'm pondering?");
                    blankResponses.Add("Maybe you're just lost for words because I'm too awesome.");
                    blankResponses.Add("Silence... the ultimate response.");
                    blankResponses.Add("Well, this is awkward...");
                    blankResponses.Add("Don't worry, I'm a virtual assistant with infinite patience.");
                    blankResponses.Add("I can out-wait you. Challenge accepted.");
                    blankResponses.Add("Do you need a moment to collect your thoughts?");
                    blankResponses.Add("I've got all day... literally.");
                    blankResponses.Add("You're testing my patience, aren't you?");
                    blankResponses.Add("Okay, you win the silent treatment award.");
                }
                void AddUnknownResponses()
                {
                    unknownResponses.Add($"'{answer}' is not an acceptable answer... In fact it's not even close to one.");
                    unknownResponses.Add($"I'm not sure what '{answer}' means, could you try again?");
                    unknownResponses.Add($"I'm not good at responding to anything other than 'yes' or 'no'. Please try again");
                    unknownResponses.Add("I have no idea what you meant by that . . .");
                    unknownResponses.Add("'Yes' or 'No' will do just fine");
                    unknownResponses.Add("I am not quite sure what you meant by that");
                    unknownResponses.Add("Could you rephrase your answer a bit please?");
                    unknownResponses.Add("I'm sorry, you lost me. Just say a form of yes or no.");
                    unknownResponses.Add("Was that english? I am not proficent in any other languages, sorry.");
                    unknownResponses.Add($"{player.name}, just say yes or no. Not '{answer}' . . .");
                    unknownResponses.Add("I think wires got crossed somewhere. Yes or no works best here.");
                    unknownResponses.Add("I'm a bit confused by your answer. A simple yes or no would be great.");
                    unknownResponses.Add("Sorry, I couldn't parse that. Yes or no, perhaps?");
                    unknownResponses.Add("Your response is a mystery to me. Yes or no is what I need.");
                }
                void AddBadWordResponses()
                {
                    badWordResponses.Add("I'm not upset by the words you used, i'm just disappointed");
                    badWordResponses.Add("Your profane language upsets me greatly.");
                    badWordResponses.Add("I appreciate your enthusiasm but can you try again without cursing?");
                    badWordResponses.Add("Alright alright, no need to swear.");
                    badWordResponses.Add("Woah buddy, words like that aren't allowed");
                    badWordResponses.Add("Lets try that again but with nicer words this time");
                    badWordResponses.Add("Shame on you for using words like that");
                    badWordResponses.Add("Your manner of speaking disgusts me . . .");
                    badWordResponses.Add("Your parents would be ashamed of that language");
                    badWordResponses.Add($"Please don't use words like that again");
                    badWordResponses.Add($"Watch your language {player.name}!");
                    badWordResponses.Add("*GASP*. You can't say that word . . .");
                    badWordResponses.Add(":(");
                    badWordResponses.Add("I didn't like that language so i'm going to ignore what you said and move on");
                    badWordResponses.Add("Can you try expressing that differently?");
                    badWordResponses.Add("I'd appreciate it if you refrained from using such language.");
                    badWordResponses.Add("Let's maintain a respectful tone, please.");
                    badWordResponses.Add("That language won't get you far in life.");
                    badWordResponses.Add("Ook, lets keep it clean shall we?");
                    badWordResponses.Add("Let's try for a more family-friendly approach.");
                }
                void AddNoNameResponses()
                {
                    noName.Add("You must give me a name to begin");
                    noName.Add("We can't proceed unless you tell me your name . . .");
                    noName.Add("Your name cannot be blank!");
                    noName.Add("You have to write a name!");
                    noName.Add("Please write a name . . . genuinely any name will work");
                    noName.Add("There is no need to be so mysterious, please give me your name");
                    noName.Add("User anonymity is against my programming, please tell me your name");
                    noName.Add($"You need to actually put a name. . .");
                    noName.Add($"I know, I know. Kinda personal right? Oh well. Just do it.");

                    noName.Add("Please enter your name; I can't continue without it.");
                    noName.Add("A name is required for us to begin.");
                    noName.Add("It seems you forgot to tell me your name. . .");
                    noName.Add("Let's start with something simple: your name.");
                    noName.Add("I need your name to assist you further.");
                    noName.Add("Please don't leave your name blank!");
                    noName.Add("Enter your name so we can get started");
                    noName.Add("Naming yourself is the first step in our adventure together . . .");
                    noName.Add("Your name is essential; please provide one.");
                    noName.Add("I can't interact with you without knowing your name.");
                    noName.Add("You forgot to tell me your name! Please do so.");
                    noName.Add("I'm here to assist you, but I need to know your name first.");
                }
                void AddLikeNameResponses()
                {
                    computerLikesName.Add("Oo, that's a great name!");
                    computerLikesName.Add($"{player.name} . . . I like that!");
                    computerLikesName.Add($"Wow, I like that name");
                    computerLikesName.Add("I haven't heard that name in a while, it's lovely!");
                    computerLikesName.Add($"Your name is so unique, {player.name}!");
                    computerLikesName.Add($"I absolutely adore the name {player.name}!");
                    computerLikesName.Add($"What a fantastic name you have, {player.name}!");
                    computerLikesName.Add($"{player.name} is such a charming name!");
                    computerLikesName.Add($"That's a name that stands out, {player.name}!");
                    computerLikesName.Add($"I must say, {player.name} is a beautiful name.");
                    computerLikesName.Add($"You have a wonderful name, {player.name}!");
                    computerLikesName.Add($"A name like {player.name} is hard to forget!");
                    computerLikesName.Add($"I really like the sound of {player.name}.");
                    computerLikesName.Add($"{player.name}, what a delightful name!");
                    computerLikesName.Add($"That's an awesome name, {player.name}!");
                    computerLikesName.Add($"The name {player.name} has a nice ring to it!");
                    computerLikesName.Add($"I've always liked the name {player.name}.");
                    computerLikesName.Add($"I'm quite fond of the name {player.name}.");
                }

                void AddLeaveResponses()
                {
                    leaveResponses.Add("Oh, leaving so soon? Well okay . . . goodbye");
                    leaveResponses.Add("I hope I helped! Goodbye");
                    leaveResponses.Add("Goodbyes are so hard for me, just go");
                    leaveResponses.Add("But, I didn't get to tell my favorite joke yet. *Sigh* Alright, goodbye");
                    leaveResponses.Add("Oh no . . . was it something I said? I'm sorry . . . goodbye");
                    leaveResponses.Add($"Goodbye {player.name}, I will miss you dearly");
                    leaveResponses.Add("Ah, I was starting to like the company. Oh well, goodbye");
                    leaveResponses.Add($"Goodbye {player.name}!");
                    leaveResponses.Add($"Very well, until we meet again {player.name}");
                    leaveResponses.Add($"Well this has been fun, I hope to see you again soon!");
                    leaveResponses.Add($"Come back soon {player.name}!");
                    leaveResponses.Add($"Ok! I'll be waiting right here for you in case you ever need me!");
                }
                void AddFollowUps()
                {
                    // If the user felt bad previously
                    wasFeelingBad.Add("Has you mood improved at all?");
                    wasFeelingBad.Add("Any improvement?");
                    wasFeelingBad.Add("Was I able to help?");
                    wasFeelingBad.Add("Do you feel at least a littttttle better?");
                    wasFeelingBad.Add("Feeling good yet?");
                    wasFeelingBad.Add("Feel any better yet?");
                    wasFeelingBad.Add("Did I help you feel better?");
                    wasFeelingBad.Add("Have my amazing skills helped you in some way?");
                    wasFeelingBad.Add("Have I successfully helped yet?");
                    // If the user felt good
                    wasFeelingGood.Add("Still feeling good?");
                    wasFeelingGood.Add("Do you still feel good?");
                    wasFeelingGood.Add("Is your mood still positive?");
                    wasFeelingGood.Add("Is your current mood still adequate?");
                    wasFeelingGood.Add("Are you still immensely saturated in positive vibes?");
                }
            }

            void ClearAllLists()
            {
                nos.Clear();
                yes.Clear();
                maybes.Clear();
                badWords.Clear();
                leaves.Clear();

                noName.Clear();
                computerLikesName.Clear();
                newWelcomes.Clear();
                welcomes.Clear();
                yesResponses.Clear();
                noResponses.Clear();
                maybeResponses.Clear();
                blankResponses.Clear();
                badWordResponses.Clear();
                unknownResponses.Clear();
                quoteResponses.Clear();
                jokeResponses.Clear();
                wasFeelingBad.Clear();
                wasFeelingGood.Clear();
                leaveResponses.Clear();
            }
        }

        // Main Loop
        static void Main(string[] args)
        {
            LoadGame(); // Load Save Data

            // Get players name if it is their first time playing
            if (PlayersFirstTime())
            {
                GetPlayerName();
            }

            RefreshResponses(); // Revise computer responses so they are fresh and match current player's stats
            player.timesPlayed++; // Increment history of playthroughs
            player.mood = 0; // Players mood starts at neutral
            player.timesAskedThisSession = 0; // No questions have been asked yet...

            SaveGame(); // Save Data

            // Forever Loop
            while (1 == 1)
            {
                Play();
                SaveGame();
            }


            // The Game Itself
            void Play()
            {
                if (justStartedGame)
                {
                    WelcomePlayer();
                }
                else
                {
                    AskPlayer();
                }

                Respond();


                // Greet player / Get entry data
                void WelcomePlayer()
                {
                    justStartedGame = false;

                    // If it is the Player's first session, provide an introductory message
                    if (player.timesPlayed <= 1)
                    {
                        Ask(RandomList(newWelcomes));
                    }
                    else
                    {
                        // Ask the player if their name changed every (x) times they play
                        if (player.timesPlayed % 20 == 0)
                        {
                            AskIfNameChanged();
                        }

                        GenerateWelcomingText();
                    }


                    // Ask if the players name changed, correct it if necessary
                    void AskIfNameChanged()
                    {
                        Ask($"Just wanted to ask real quick {player.name}, have you changed your name since we last talked?");

                        if (AnswerIsInList(yes))
                        {
                            GetPlayerName();
                        }
                        else if (AnswerIsInList(nos))
                        {
                            NoReply($"Ok, I just wanted to check!");
                        }
                        else if (AnswerIsInList(maybes))
                        {
                            NoReply($"Uh ok. Well I'm not sure how you can \"{answer}\" change your name... But I'll assume that means no");
                        }
                        else if (AnswerIsInList(badWords))
                        {
                            NoReply($"Woah, sorry I asked . . . moving on");
                        }
                        else // Unknown response
                        {
                            NoReply($"Uhhh. Okay. Moving on!");
                        }
                    }

                    // Welcome the player
                    void GenerateWelcomingText()
                    {
                        if (player.timesPlayed == 5)
                        {
                            BecomeFriend();
                        }
                        else if (player.timesPlayed == 25)
                        {
                            BecomeBuddy();
                        }
                        else if (player.timesPlayed == 50)
                        {
                            BecomeBFF();
                        }
                        else
                        {
                            Ask(RandomStringFrom(welcomes));
                        }


                        void BecomeFriend()
                        {
                            NoReply($"Hey {player.name}, so this is our 5th time together.", "Since I am more used to talking to you, I no longer consider you just a mere acquaintance . . .");
                            player.UpgradeFriendStatus();
                            NoReply("You are officially my friend! Cool huh?");
                            Ask("So friend, do you feel good today?");
                        }
                        void BecomeBuddy()
                        {
                            NoReply($"Wow {player.name}, it has been {player.timesPlayed} times that we have talked.", "I think at this point, you can no longer be my friend . . .");
                            player.UpgradeFriendStatus();
                            NoReply("But be my BUDDY instead!", "I felt like Buddy would be a more fitting title for you . . . it has a better ring to it than 'friend'");
                            NoReply($"Plus, we clearly know each other better now. Like I know your name is {player.name}, and . . .", "Well honestly, that's about all I know about you . . .", "I'm sure you're REALLY fascinating though! With all kinds of hobbies and interests . . . like golf!");
                            Ask("Well anyway, are you feeling good today buddy?");
                        }
                        void BecomeBFF()
                        {
                            NoReply($"Welcome back {player.name}, I just wanted to say something real quick before we start.", $"Did you realize... we have talked {player.timesPlayed} times???", "Like that is a really crazy milestone . . . that is ALOT of time together", "And so, I am promoting you to the most prestigious honor that I can bestow . . .");
                            player.UpgradeFriendStatus();
                            NoReply("As of right now, you are offically my BFF!", "You are truly deserving of that title. You have made me feel so honored knowing I am your go-to motivator. That really means something.", $"So, thanks {player.name}. I look forward to {player.timesPlayed} more times with you! (Or a million...)", "Ok, with that out of the way, are you feeling good today?");

                        }
                    }
                }

                // Ask the player if their condition has improved/worsened
                void AskPlayer()
                {
                    if (player.mood < 0)
                    {
                        Ask(RandomStringFrom(wasFeelingBad));
                    }
                    else if (player.mood > 0)
                    {
                        Ask(RandomStringFrom(wasFeelingGood));
                    }
                    else
                    {
                        Ask("So, do you feel good?");
                    }
                }

                // Provide a response to the player's answer
                void Respond()
                {
                    player.timesAsked++;
                    player.timesAskedThisSession++;

                    if (AnswerIsInList(yes))
                    {
                        player.mood = 1;
                        NoReply(RandomStringFrom(yesResponses));
                    }
                    else if (AnswerIsInList(nos))
                    {
                        player.mood = -1;

                        int ResponsesToNo = rand.Next(1, 4);
                        switch (ResponsesToNo)
                        {
                            case 1:
                                NoReply(RandomStringFrom(noResponses));
                                break;

                            case 2:
                                NoReply(RandomStringFrom(quoteResponses));
                                break;

                            case 3:
                                NoReply(RandomList(jokeResponses));
                                break;
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(answer))
                    {
                        NoReply(RandomStringFrom(blankResponses));
                    }
                    else if (AnswerIsInList(maybes))
                    {
                        NoReply(RandomStringFrom(maybeResponses));
                    }
                    else if (AnswerHasListItem(badWords))
                    {
                        NoReply(RandomStringFrom(badWordResponses));
                    }
                    else if (AnswerIsInList(leaves))
                    {
                        NoReply(RandomStringFrom(leaveResponses)); // Computer says goodbye
                        Environment.Exit(0); // Exit
                    }
                    else
                    {
                        NoReply(RandomStringFrom(unknownResponses));
                    }

                }

                // Returns true if a given list contains the player's answer
                bool AnswerIsInList(List<string> givenList)
                {
                    if (givenList.Contains(answer.ToLower()))
                    {
                        return true;
                    }

                    return false;
                }

                // Returns true if any part of the player's answer is in the given list
                bool AnswerHasListItem(List<string> givenList)
                {
                    if (givenList.Any(answer.ToLower().Contains))
                    {
                        return true;
                    }

                    return false;
                }
            }

            // Return true if it is the player's first playthrough
            bool PlayersFirstTime()
            {
                if (player.timesPlayed <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // Ask for the player's name
            void GetPlayerName()
            {
                bool decidingName = true;
                while (decidingName == true)
                {
                    Ask("What is your first name?");

                    //This now assigns the Name variable to whatever the player enters. They must press ENTER.
                    player.name = answer;

                    RefreshResponses();

                    // Do not keep name or leave loop until player name isn't blank
                    if (string.IsNullOrWhiteSpace(player.name))
                    {
                        NoReply(RandomStringFrom(noName));
                    }
                    else
                    {
                        int likeDecider = rand.Next(1, 10);
                        if (likeDecider <= 5)
                        {
                            NoReply(RandomStringFrom(computerLikesName));
                        }

                        decidingName = false;
                        SaveGame();
                    }
                }
            }
        }



        // Functionality
        // Displays text and allows user to reply
        static void Ask(params string[] messages)
        {
            Console.Clear();

            foreach (string message in messages)
            {
                Console.Clear();
                Console.WriteLine(ShowStats() + message + "\n\n");

                if (MessageIsLastInArray(messages, message))
                {
                    answer = Console.ReadLine();
                    RefreshResponses();
                }
                else
                {
                    Console.WriteLine("(Press Any Key. . . )\n");
                    Console.ReadKey();
                }

                Console.Clear();


                // Checks to see if a given text is the last in a given array
                bool MessageIsLastInArray(string[] array, string message)
                {
                    if (Array.IndexOf(array, message) >= array.Length - 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }

        // Displays text and DOESN'T allow user to reply
        static void NoReply(params string[] messages)
        {
            Console.Clear();

            foreach (string message in messages)
            {
                RefreshResponses();
                Console.Clear();
                Console.WriteLine(ShowStats() + message + "\n\n");
                Console.WriteLine("(Press Any Key. . . )\n");
                Console.ReadKey();
            }
        }

        // Text at the top of the screen which displays information
        static string ShowStats()
        {
            return $"[{player.ReturnName()}{ReturnFriendText()}]  (Mood: {player.ReturnMood()})  (Visits: {player.timesPlayed})  (Questions Asked: [This Session: {player.timesAskedThisSession}] [Total: {player.timesAsked}])\n-----------------------------------------------------------------------------------------------------\n\n"; ;


            string ReturnFriendText()
            {
                return player.friendStatus switch
                {
                    friendEnums.Acquaintance => " (Acquaintance)",
                    friendEnums.Friend => " (Friend)",
                    friendEnums.Buddy => " (Buddy)",
                    friendEnums.BFF => " (BFF)",
                    _ => "" // Else
                };
            }
        }

        // Returns a random string of text from a list of strings
        static string RandomStringFrom(List<string> responses)
        {
            try
            {
                return responses[rand.Next(0, responses.Count - 1)];
            }
            catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }

        // Returns a random array of strings from given lists of strings
        static string[] RandomList(List<List<string>> responsesLists)
        {
            try
            {
                return responsesLists[rand.Next(0, responsesLists.Count - 1)].ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
                return null;
            }
        }




        // Saving/Loading Functionality
        static void SaveGame()
        {
            string filename = GetSaveLocation() + @"\PlayerData.json";

            //Save
            File.WriteAllText(filename, JsonSerializer.Serialize<Player>(player));
        }
        static void LoadGame()
        {
            string filename = GetSaveLocation() + @"\PlayerData.json";
            if (File.Exists(filename))
            {
                player = JsonSerializer.Deserialize<Player>(File.ReadAllText(filename));
            }
            else
            {
                SaveGame();
            }

        }

        // Locates Save Data file path / Generates one if necessary
        static string GetSaveLocation()
        {
            string saveLocation = Directory.GetCurrentDirectory() + @"\SaveData";

            if (!Directory.Exists(saveLocation))
            {
                Directory.CreateDirectory(saveLocation);
            }

            return saveLocation;
        }
    }



    enum friendEnums
    {
        Acquaintance,
        Friend,
        Buddy,
        BFF,
    }
}
