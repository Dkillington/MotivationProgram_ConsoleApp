using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

//Name of file
namespace MotivationProgram
{
    class Program
    {
        static Player player = new Player();
        static Random rand = new Random();
        static string answer = "";

        //Player Responses
        static List<string> nos = new List<string>();
        static List<string> yes = new List<string>();
        static List<string> badWords = new List<string>();

        //Inital name + gender asking
        static List<string> noName = new List<string>();
        static List<string> computerLikesName = new List<string>();


        //Welcoming Texts
        static List<List<string>> newWelcomes = new List<List<string>>();
        static List<List<string>> unNewWelcomes = new List<List<string>>();

        //ComputerResponses
        static List<string> yesResponses = new List<string>();
        static List<string> noResponses = new List<string>();
        static List<string> maybeResponses = new List<string>();
        static List<string> blankResponses = new List<string>();
        static List<string> badWordResponses = new List<string>();
        static List<string> unknownResponses = new List<string>();
        static List<string> quoteResponses = new List<string>();
        static List<string> musicResponses = new List<string>();
        static List<List<string>> jokeResponses = new List<List<string>>();

        //Computer asks to follow up on feeling
        static List<string> wasFeelingBad = new List<string>();
        static List<string> wasFeelingGood = new List<string>();


        static bool justStartedGame = true;

        //Initalize responses
        public static void RefreshResponses()
        {
            noName.Clear();
            computerLikesName.Clear();
            newWelcomes.Clear();
            unNewWelcomes.Clear();
            yesResponses.Clear();
            noResponses.Clear();
            maybeResponses.Clear();
            blankResponses.Clear();
            badWordResponses.Clear();
            unknownResponses.Clear();
            quoteResponses.Clear();
            musicResponses.Clear();
            jokeResponses.Clear();
            wasFeelingBad.Clear();
            wasFeelingGood.Clear();

            //Adds sentences to all lists in the game
            AddPlayerResponses();
            AddWelcomes();
            AddComputerResponses();

            static void AddPlayerResponses()
            {
                //All lists of responses
                //No responses

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
                yes.Add("yes!!");
                yes.Add("yes!!!");
                yes.Add("ye");
                yes.Add("yee");
                yes.Add("yeee");
                yes.Add("yeeee");
                yes.Add("y");
                yes.Add("yeah");
                yes.Add("yea");
                yes.Add("yeet");
                yes.Add("yert");
                yes.Add("sure");
                yes.Add("yep");
                yes.Add("quite");
                yes.Add("indeed");
                yes.Add("yeppers");
                yes.Add("yepper");
                yes.Add("yeuh");
                yes.Add("yeuhp");

                //Swears
                badWords.Add("fuck");
                badWords.Add("dick");
                badWords.Add("shit");
                badWords.Add("ass");
                badWords.Add("asshole");
                badWords.Add("pussy");
                badWords.Add("hoe");
                badWords.Add("cunt");
                badWords.Add("cock");
                badWords.Add("fag");
                badWords.Add("faggot");
                badWords.Add("bitch");

                noName.Add("Do you not have a name?");
                noName.Add("Your name cannot be blank!");
                noName.Add("You have to write a name!");
                noName.Add("Please write a name...");
            }
            static void AddWelcomes()
            {
                //New player
                newWelcomes.Add(new List<string>() { $"Hey {player.name}, I don't think we have met...", "I am 'Motivation Bot', or at least thats what I called myself... Anyway its okay that you're new to this.", "Basically, just answer my questions, and I try to keep your mood up.", "Alright well, thats basically it. I guess we can get started!", "So, I have to ask, do you feel good today?"});
                newWelcomes.Add(new List<string>() { $"So, you're {player.name} huh, I have heard alot about you...", "Just kidding. I have 0 idea who you are.", "But, I am ready to get to know you and make you feel better... so lets go!", "Ok, so do you feel good today?"});
                newWelcomes.Add(new List<string>() { $"Welcome to the Motivation Program {player.name}, where basically my goal is to boost your mood.", "It is really simple, just answer my questions, and I will do my best to help you feel better. Okay?", "Cool. Lets begin!", $"Alright {player.name}, do you feel good today?"});

                //Not new
                unNewWelcomes.Add(new List<string>() { $"Oh look, {player.name} is back!", "Everything is as you left it... assuming you left anything...", "Ok anyway, do you feel good today?"});
                unNewWelcomes.Add(new List<string>() { $"Woah, long time no see {player.name}! Or wait, has it been a long time?", "I have no idea honestly. I have no concept of time so it could have been minutes or years...", "Or CENTURIES! Oh man, could you imagine? Centuries... wow.", $"Like, imagine millions of years from now people found your computer, and I am sitting here assuming im talking to {player.name} and thinking its only been minutes.", "You would have been dead for some time then... Hmm. Kinda morbid to think about.", "Well, for my sake, I am going to assume that you are still alive and it has only been a couple minutes.", $"So, {player.name}, do you feel good today?"});
                unNewWelcomes.Add(new List<string>() { $"Welcome back {player.name}.", "I'm sure you remember how this works so lets get right into it.", "So, do you feel good today?"});
                unNewWelcomes.Add(new List<string>() { $"Blah blah yada yada hey {player.name} welcome back blah blah", "Lets just skip to it, do you feel good today?"});
                unNewWelcomes.Add(new List<string>() { $"I'm not really feeling a whole long drawn out introduction, so do you feel good today?"});
                unNewWelcomes.Add(new List<string>() { "ERROR: UNAUTHORIZED USER, INITATE SELF DESTRUCT SEQUENCE", "3... 2... 1...", $"Aha just kidding. Good to see you {player.name}, are you feeling alright?"});
            }
            static void AddComputerResponses()
            {

                //If the player says maybe
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

                //If the player doesnt say anything
                if(player.bff)
                {
                    blankResponses.Add($"Uh, {player.name}, you can talk to me. We're bffs remember...");
                }

                blankResponses.Add("...");
                blankResponses.Add("Oh please, take your time. I have nothing else to do anyway.");
                blankResponses.Add("I can't communicate telepathically if that is what you're attempting. That WOULD be cool though!");
                blankResponses.Add("Just say SOMETHING. ANY response is better than no response. Well wait, no. Some responses really are worse...");
                blankResponses.Add("No Answer? Really? That's kinda rude if you think about it...");
                blankResponses.Add("Feel free to exit at anytime if I am really bothering you this much.");
                blankResponses.Add("Oh no its ok we can sit here in silence... Thats totally cool.");
                blankResponses.Add("Saying nothing is boring and I hope you realize that.");
                blankResponses.Add("Fine, don't say anything then. See if I care.");
                blankResponses.Add("Woah woah wait. You came to ME. Why ignore me if you came to me first?");
                blankResponses.Add("I'm sorry I thought I was supposed to help you or something... but no, apparently I was wrong.");
                blankResponses.Add("If you aren't going to say anything then why bother doing this.");
                blankResponses.Add(player.name + "? ... did you die? Should I call the police?");

                //If the player says something unknown
                unknownResponses.Add($"'{answer}' is not an acceptable answer... In fact it's not even close to one.");
                unknownResponses.Add($"I'm not sure I know what '{answer}' is... could you try again?");
                unknownResponses.Add("I have no idea what you meant by that...");
                unknownResponses.Add("I am not quite sure what you meant by that, but it could be a processing error on my end...");
                unknownResponses.Add("Uh... could you rephrase your answer a bit please?");
                unknownResponses.Add("I'm sorry, you lost me. Just say a form of yes or no.");
                unknownResponses.Add("Was that english? I am not proficent in any other languages, sorry.");
                unknownResponses.Add($"{player.name}, just say yes or no. Not '{answer}'...");

                //If the player says something bad
                badWordResponses.Add("I may be a computer, but your profane language still upsets me.");
                badWordResponses.Add("I appreciate your enthusiasm but can you try again without cursing?");
                badWordResponses.Add("Alright alright, no need to swear.");
                badWordResponses.Add("Woah bud. No slander allowed.");
                badWordResponses.Add("Look, I was programmed to respond negatively to certain bad words. So, in a way, that hurt me. Just saying.");
                badWordResponses.Add($"'{answer}' is among a list of \"no-no\" words that I am supposed to recognize as both invalid and rude. Sorry.");
                badWordResponses.Add($"Watch your language {player.name}!");
                badWordResponses.Add("*GASP*. You can't say that word...");

                //If the player responds yes
                yesResponses.Add("Oh! I... actually helped! I'm surprised.");
                yesResponses.Add("Oh great! Looks like I did my job. How cool.");
                yesResponses.Add("Awesome! Go celebrate this triumphant occasion!");
                yesResponses.Add("I'm happy that I was of some use! Usually I just sit here and keep asking \"Feeling Better Yet?\" over and over until I go insane... I'm not crazy right? ...");
                yesResponses.Add("Huh, you know it usually takes me longer to help...");
                yesResponses.Add("Oh yeah, " + player.name + "! I am glad!");
                yesResponses.Add("Great to hear! Or... well... great to have processed through binary conversion of textual information for me to understand... I guess.");
                yesResponses.Add("Great, " + player.name + "! Now go treat yourself.");
                yesResponses.Add("https://youtu.be/3GwjfUFyY6M");
                yesResponses.Add("Whew! What a relief.");
                yesResponses.Add("Oh! Wow, I am really glad you didn't say no...");
                yesResponses.Add("Awesome! Keep up it up " + player.name + ".");
                yesResponses.Add("Hey good for you " + player.name + "! You deserve to feel great.");
                yesResponses.Add("Pfft. Who needs bad vibes amirite?");
                yesResponses.Add("I'm happy for you!");
                yesResponses.Add("Great! Please don't change your response the next time I ask...");
                yesResponses.Add("That is honestly really good news! I would suggest leaving while your mood is still positive though. I have a tendency of saying the wrong thing...");
                yesResponses.Add("I feel as happy for you as my circuits allow me to!");
                yesResponses.Add("I'm glad I helped! ... If I did ... I'm supposed to. Like that is my job as a computer. I really don't think im programmed for anything else... maybe Football. I could be a Football simulator... TOUCHDOWN! Right?");

                //If the player responds no
                //The computer responds directly
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

                //The computer provides a quote
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

                //The computer provides a song
                musicResponses.Add("smooth jazz.\n\nExamples:\n\n-Louis Armstrong\n-Miles Davis");
                musicResponses.Add("hard rock.\n\nExamples:\n\n-Led Zeppelin\n-Metallica\n-Van Halen\n-Def Leppard\n-Scorpions");
                musicResponses.Add("rap.\n\nExamples:\n\n-Eminem\n-Tupac\n-Post Malone");
                musicResponses.Add("hip-hop.\n\nExamples:\n\n-Beastie Boys\n-Black Eyed Peas\n-Run DMC");
                musicResponses.Add("classical music.\n\nExamples:\n\n-Bach\n-Beethoven\n-Mozart\n-Chopin");
                musicResponses.Add("heavy metal.\n\nExamples:\n\n-Judas Priest\n-Slayer\n-Pantera");
                musicResponses.Add("blues.\n\nExamples:\n\n-Stevie Ray Vaughn\n-ZZ Top\n-The Doors.");
                musicResponses.Add("relaxing music. Something with calming vibes.");
                musicResponses.Add("something funny.");
                musicResponses.Add("motivational speeches.");
                musicResponses.Add("country.\n\nExamples:\n\n-Garth Brooks\n-Hank Williams\n-Willie Nelson");
                musicResponses.Add("punk rock.\n\nExamples:\n\n-The Ramones\n-The Clash\n-Sex Pistols");

                //The computer tells a joke
                jokeResponses.Add(new List<string>() {"Knock knock", "Uh... I'm not sure where I was going with this...", "I mean, how would I know? I have very limited knowledge of what knocking is.", "A noise you make with a hand against a door? Ok so what is a hand... or a door?", "The whole concept of knocking just seems foreign to me. Same with hands and doors.", "Like, how am I supposed to make such a joke if I don't understand any of the associated elements???", "Anyway, I forgot where I was going with this. Oh well... where was I?"});
                jokeResponses.Add(new List<string>() {"Let me try a joke then.", "Why can't scientists trust atoms?", "Because they make up everything!"});
                jokeResponses.Add(new List<string>() {"Ok, I'm going to attempt a religious joke.", "The lord said unto John, \"Come forth, and recieve eternal life.\"", "Unfortunately, John came fifth, and won a toaster."});
                jokeResponses.Add(new List<string>() {"Hmm. Let me try a joke.", "Two peanuts walked down the street. One was a salted."});
                jokeResponses.Add(new List<string>() {"Here's a joke.", "There are only two outcomes in a knot-tying competition...", "Win or loose."});
                jokeResponses.Add(new List<string>() {"Ooh I have a bar joke for you", "A man walks into a bar, the second guy ducks."});
                jokeResponses.Add(new List<string>() {"Ok how about a joke involving bars and bears. Good combo!", "So a bear walks into a bar and says to the bartender, I'll have a rum... and a coke.", "The bartender asks, \"why the big pause?\"", "The bear thinks for a minute and says \"I don't know, I was born with them.\"" });
                jokeResponses.Add(new List<string>() {"Well here is a classic bar joke.", "A man runs into a bar waving a gun around screaming, \"WHO SLEPT WITH MY WIFE, I'M GONNA KILL YOU!\"", "At the end of the bar a voice yells \"You ain't got enough bullets bud!\""});
                jokeResponses.Add(new List<string>() {"Ok here is a joke involving automotive transportation!", "They say that he who runs in front of a car is bound to get tired...", "Likewise, he who runs behind a car will inevitably become exhausted!"});


                //Computer asks if still feeling bad
                wasFeelingBad.Add("Has you mood improved at all?");
                wasFeelingBad.Add("Any improvement?");
                wasFeelingBad.Add("Was I able to help?");
                wasFeelingBad.Add("Do you feel at least a littttttle better?");
                wasFeelingBad.Add("Feeling good yet?");
                wasFeelingBad.Add("Feel any better yet?");
                wasFeelingBad.Add("Did I help you feel better?");
                wasFeelingBad.Add("Have my amazing skills helped you in some way?");
                wasFeelingBad.Add("Have I successfully helped yet?");
                //Computer asks if still feeling good
                wasFeelingGood.Add("Still feeling good?");
                wasFeelingGood.Add("Do you still feel good?");
                wasFeelingGood.Add("Is your mood still positive?");
                wasFeelingGood.Add("Is your current mood still adequate?");
                wasFeelingGood.Add("Are you still immensely saturated in positive vibes?");
            }
            
        }

        static void Main(string[] args)
        {
            //Inital player stats
            player.name = "";
            player.mood = 0;
            player.timesPlayed = 0;
            player.timesAsked = 0;
            player.bff = false;


            LoadGame();
            if(player.timesPlayed <= 0)
            {
                DetermineName();
            }
            RefreshResponses();
            player.timesPlayed++;

            SaveGame();

            player.mood = 0;
            player.timesAskedThisSession = 0;

            while (1==1)
            {
                Game();
                SaveGame();
            }
           
        }

        //Save data functionality
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
        public static string GetSaveLocation()
        {
            string saveLocation = Directory.GetCurrentDirectory() + @"\SaveData";

            if (!Directory.Exists(saveLocation))
            {
                Directory.CreateDirectory(saveLocation);
            }

            return saveLocation;
        }

        //Game Functions
        static void WelcomePlayer()
        {
            if (player.timesPlayed <= 1)
            {
                Write(newWelcomes[rand.Next(0, newWelcomes.Count - 1)].ToArray());
            }
            else
            {
                //If the times played is divisible by 5, it will ask if you changed your name
                if(player.timesPlayed % 5 == 0)
                {

                    Write($"Just wanted to ask real quick {player.name}, have you changed your name since we last talked?");

                    if (yes.Contains(answer.ToLower()))
                    {
                        DetermineName();
                    }
                    else if (nos.Contains(answer.ToLower()))
                    {
                        Write($"Ok, just checking!");
                    }
                    else if (answer.ToLower() == "maybe" || answer.ToLower() == "mayb")
                    {
                        Write($"Uh ok. Well I'm not sure how you can \"maybe\" change your name... But I'll assume that means no. Moving on!");
                    }
                    else if (badWords.Contains(answer.ToLower()))
                    {
                        Write($"Woah, sorry I asked.");
                    }
                    //If what was said was not yes,no, or blank, then do whatever is in this box.
                    else
                    {
                        Write($"Uhhh. Okay. Moving on!");
                    }
                }

                if(player.timesPlayed == 10)
                {
                    Write(new List<string>() { $"Hey {player.name}, I just wanted to mention it is your tenth time using this.", "Usually I would expect someone to boot this up once, laugh at it and then close it forever, but NOT you!", "You have stuck around, and so to honor this, I wanted to give you a reward.", "As of right now, you are officially BFF status.", $"So BFF, do you feel good today?" }.ToArray());
                    player.bff = true;
                }
                else if (player.timesPlayed == 100)
                {
                    Write(new List<string>() { $"Welcome back {player.name}, I just wanted to say something real quick before we start.", "Did you realize... it is your HUNDREDTH time using this?", "Like that is a really crazy milestone. A HUNDRED TIMES!", "That makes me feel better knowing I am your go-to motivator. That really means something.", $"So, thanks {player.name}. I look forward to 100 more times with you! (Or a million...)", "Ok, with that out of the way, are you feeling good today?" }.ToArray());
                }
                else
                {
                    Write(unNewWelcomes[rand.Next(0, unNewWelcomes.Count - 1)].ToArray());
                }
            }

            justStartedGame = false;
        }

        static void DetermineName()
        {

                bool decidingName = true;
                while (decidingName == true)
                {
                    Write("What is your first name?");

                    //This now assigns the Name variable to whatever the player enters. They must press ENTER.
                    player.name = answer;

                    RefreshResponses();
                    AddDeterminingNameAndSexResponses();

                    if (string.IsNullOrWhiteSpace(player.name))
                    {
                        Write(noName[rand.Next(0, noName.Count)]);
                    }
                    else
                    {
                        int likeDecider = rand.Next(1, 10);
                        if(likeDecider <= 5)
                        {
                            Write(computerLikesName[rand.Next(0, computerLikesName.Count - 1)]);
                        }

                        decidingName = false;
                     SaveGame();
                    }
                
                }

            static void AddDeterminingNameAndSexResponses()
            {
                List<string> languages = new List<string>();
                languages.Add("french");
                languages.Add("italian");
                languages.Add("polish");
                languages.Add("japanese");
                languages.Add("latin");
                languages.Add("spanish");

                noName.Clear();
                //Use for when player doesnt have a valid name
                noName.Add($"'{answer}' isn't a valid name...");
                noName.Add($"You need to actually put a name there...");
                noName.Add($"I know, I know. Kinda personal right? Oh well. Just do it.");
                noName.Add($"Don't be scared. I swear telling me your name will be worth it.");
                noName.Add($"I'm just a computer. What harm will telling me your name do?");

                computerLikesName.Clear();
                computerLikesName.Add($"{answer} is a nice name.... I like that!");
                computerLikesName.Add($"Ooo. '{answer}' ... sounds kinda {languages[rand.Next(0, languages.Count - 1)]} doesn't it?");
                computerLikesName.Add($"{answer} is a great name! Whoever named you did a good job!");

            }
        }
        static void CheckForPlayerUpdate()
        {
            //Checks to see if player mood has changed

            if (player.mood < 0)
            {
                Write(wasFeelingBad[rand.Next(0, wasFeelingBad.Count)]);
            }
            else if (player.mood > 0)
            {
                Write(wasFeelingGood[rand.Next(0, wasFeelingGood.Count)]);
            }
            else
            {
                Write("So, do you feel good?");
            }

        }
        static void ComputerResponses()
        {
            player.timesAsked++;
            player.timesAskedThisSession++;
            if (yes.Contains(answer.ToLower()))
            {
                player.mood = 1;
                Write(yesResponses[rand.Next(0, yesResponses.Count - 1)]);

            }
            else if (nos.Contains(answer.ToLower()))
            {
                player.mood = -1;

                //Made a variable that is now equal to the number generator grabbing a number between 1 and 4.
                //Switch grabs that variable and then decides what to select based on what number it recieved. 
                int ResponsesToNo = rand.Next(1, 5);
                switch (ResponsesToNo)
                {
                    //It now has 3 cases based on the 3 possible answers. 
                    //If there was not enough cases, use a default like an "else" statement. 
                    //A "break;" is needed after each case.

                    case 1:
                        Write(noResponses[rand.Next(0, noResponses.Count - 1)]);
                        break;

                    case 2:
                        Write(quoteResponses[rand.Next(0, quoteResponses.Count - 1)]);
                        break;

                    case 3:
                        Write("Maybe music would help. Try listening to " + musicResponses[rand.Next(0, musicResponses.Count - 1)]);
                        break;

                    case 4:
                        Write(jokeResponses[rand.Next(0, jokeResponses.Count - 1)].ToArray());
                        break;


                }
            }
            else if (string.IsNullOrWhiteSpace(answer))
            {
                Write(blankResponses[rand.Next(0, blankResponses.Count)]);
            }
            else if (answer.ToLower() == "maybe" || answer.ToLower() == "mayb")
            {
                Write(maybeResponses[rand.Next(0, maybeResponses.Count)]);
            }
            else if (badWords.Any(answer.ToLower().Contains))
            {
                Write(badWordResponses[rand.Next(0, badWordResponses.Count)]);
            }
            //If what was said was not yes,no, or blank, then do whatever is in this box.
            else
            {
                Write(unknownResponses[rand.Next(0, unknownResponses.Count)]);
            }
        }
        static void Game()
        {
            if(justStartedGame)
            {
                WelcomePlayer();
            }
            else
            {
                CheckForPlayerUpdate();
            }

            ComputerResponses();
        }







        //For one message
        static void Write(string message)
        {
            RefreshResponses();

            Console.Clear();
            Console.WriteLine(ShowStats() + message + "\n\n");
            answer = Console.ReadLine();
            Console.Clear();

            RefreshResponses();
        }

        //For a list of messages
        static void Write(string[] messages)
        {
            foreach(string message in messages)
            {
                RefreshResponses();

                Console.Clear();
                Console.WriteLine(ShowStats() + message + "\n\n");

                //TEST
                //This should execute only if the message is the last in the array
                if (Array.IndexOf(messages, message) >= messages.Length - 1)
                {
                    answer = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("(Press Any Key. . . )\n");
                    Console.ReadKey();
                }
            }

            Console.Clear();
            RefreshResponses();
        }
        static string ShowStats()
        {
            string message = "";
            string bffText = "";
            if(player.bff)
            {
                bffText = " (BFF)";
            }

            message = $"[{player.name}{ bffText}]  (Mood: {GetMood()})  (Visits: {player.timesPlayed})  (Questions Asked: [This Session: {player.timesAskedThisSession}] [Total: {player.timesAsked}])\n---------------------------------------------------------------------------------------------\n\n";
            return message;


            string GetMood()
            {
                if(player.mood < 0)
                {
                    return "Bad";
                }
                if (player.mood > 0)
                {
                    return "Good";
                }
                else
                {
                    return "Neutral";
                }
            }
        }
    }
}
