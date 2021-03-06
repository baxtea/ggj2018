﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetList : MonoBehaviour {
    public List<List<string>> tweets = new List <List<string>>();
    public List<List<Statement>> weights = new List<List<Statement>>();
    string firstname; //will be the name the player enters

    // Use this for initialization
    void Awake() {
        List<string> tweet1 = new List<string>() { "Kale farms in Kalros have been ravaged by a flood.", "Kale is a vital plant for the balance of the ecosystem. We must work to create as many sustainable farms as possible to replace those lost", "What / Who cares ? Kale is stupid anyways!It tastes supper GROSS. #NoVeggies", "Kale production is the backbone of our farms. Get out people back to work! Fix those farms! #ExportEconomy" };
        List<Statement> w1 = new List<Statement>() { new Statement {issue = Issue.Environment, stance = -0.6f}, new Statement {issue = Issue.Environment, stance = 1.0f},  new Statement {issue = Issue.Business, stance = 0.3f} };
        tweets.Add(tweet1);
        weights.Add(w1);

        List<string> tweet2 = new List<string>() { "1 in 5 people in Unidia don’t have health insurance ", "We must invest more in medical care for everyone so we can protect our citizens in the future #HealthCareReform", "But that means the other 4 have it? And I am one of those 4. The 20% can suck it. #TakeThatSickness", "People are responsible for their own health insurance. If they don’t have it, they are accepting the risk" };
        //if they click on the second choice here, its supposed to do the Oregon Trail easter egg
        List<Statement> w2 = new List<Statement>() { new Statement { issue = Issue.Domestic, stance = -0.4f }, new Statement { issue = Issue.Domestic, stance = 0.5f }, new Statement { issue = Issue.Business, stance = 0.8f } };
        tweets.Add(tweet2);
        weights.Add(w2);
        List<string> tweet3 = new List<string>() { "A shooting has occurred in Bellicity. 3 dead, 12 injured. More details on the way.", "Guns are killing our people. We need gun regulation to prevent more deaths in the future", "I bet it was an alien. REWARD if anyone finds its UFO!! #AlienInvasion", "After a tragedy like this, we must mourn, not talk about regulations. Thinking of the victims #ThoughtsAndPrayers" };
        List<Statement> w3 = new List<Statement>() { new Statement { issue = Issue.Domestic, stance = -0.9f }, new Statement { issue = Issue.Domestic, stance = 0.1f }, new Statement { issue = Issue.Guns, stance = 1f } };
        tweets.Add(tweet3);

        List<string> tweet4 = new List<string>() { "Fjordish mayor passes provision legalizing gay marriage", "Today is a day of celebration for LGBTQ+ rights! Tomorrow, we will continue to fight until equal rights are achieved.", "Why not just marry someone and sleep with who you want? Thats what I do! #TheStormIsHere", "We have had marriage rules for centuries, making marriage a sacred institution. Is it within a mayors rights to change the rules for his province? I don’t think so!" };
        List<Statement> w4 = new List<Statement>() { new Statement { issue = Issue.Feminism, stance = -1f }, new Statement { issue = Issue.Feminism, stance = 0.1f }, new Statement { issue = Issue.Domestic, stance =-0.4f } };
        tweets.Add(tweet4);

        List<string> tweet5 = new List<string>() { "12 more women allege sexual assault by major movie director, many calling for resignation", "With so many allegations of misconduct and assault, there is no question as to this man's character. I join the call for his resignation, and for more rules protecting women and the victims of assault. #MeToo", "Why are they complaining? Sounds like a fun time to me! #MeThree", "If these allegations were true, why would these women wait for so long to tell the stories? Suspicious, isn’t it?" };
        List<Statement> w5 = new List<Statement>() { new Statement { issue = Issue.Feminism, stance = -1f }, new Statement { issue = Issue.Feminism, stance = 0.5f }, new Statement { issue = Issue.Feminism, stance = 0.4f } };
        tweets.Add(tweet5);

        List<string> tweet6 = new List<string>() { "Othernian capital attacked by terrorists, 126 dead, 600+ injured in explosion of major mall", "In events like these, we need to stick by our allies and send them aid. Our campaign will donate to help treat the injured and rebuild.", "This is when we bomb them harder, right? Just fly over and drop what we have! #BiggerButton", "We must send our military to deal with these terrorists before they expand operations and attack us! #TerrorWar" };
        List<Statement> w6 = new List<Statement>() { new Statement { issue = Issue.Domestic, stance = -0.7f }, new Statement { issue = Issue.Guns, stance = 0.2f }, new Statement { issue = Issue.Guns, stance = 0.8f } };
        tweets.Add(tweet6);

        List<string> tweet7 = new List<string>() { "Republic of Not-us president calls for reduction of unidian tariffs, threatens embargo", "Without putting ourselves at a disadvantage, we will work with our allies to keep the flow of trade open. #GlobalEconomy", "Whats wrong with escargo? Its a strange dish, but it really shows your wealth! #DisturbingDelicacy", "If the Not-us Republic wants to hurt our economy, we cannot let them. We will build our own economy until we don’t need their products!" };
        List<Statement> w7 = new List<Statement>() { new Statement { issue = Issue.Business, stance = -0.8f }, new Statement { issue = Issue.Business, stance = 0.1f }, new Statement { issue = Issue.Business, stance = 1f } };
        tweets.Add(tweet7);

        List<string> tweet8 = new List<string>() { "In Variedium, crime has risen to its highest number in 25 years, 2 points above national average", "To prevent crime, we need to invest in schools. There is scientific evidence that links improved education with a drop in crime. #InvestInTheFuture", "Can we start the Purge? Maybe the criminals will just kill each other! Otherwise, at least the crime statistics will drop a bit. #WorthAShot, right?", "Police forces in Variedium are stretched thin dealing with these criminals. More officers need to be hired to keep these deplorables in line." };
        List<Statement> w8 = new List<Statement>() { new Statement { issue = Issue.Crime, stance = -0.9f }, new Statement { issue = Issue.Crime, stance = 0.1f }, new Statement { issue = Issue.Crime, stance = 0.9f } };
        tweets.Add(tweet8);

        List<string> tweet9 = new List<string>() { "Multiple companies found using racially discriminating hiring practices, representatives considering repercussions", "Such practices go against our values, and our laws. We need to be more vigilant of such practices, and ensure equality for all not just in rhetoric, but in action!", "Makes sense. I did the same at my business. Learned from the best - my Dad! #HappyFathersDay #YouDidntKnow?", "While I do not endorse such policies and would never use them myself, it is not governments place to get involved running a company. #SeperationOfBizAndState" };
        List<Statement> w9 = new List<Statement>() { new Statement { issue = Issue.Race, stance = -0.8f }, new Statement { issue = Issue.Business, stance = 0.1f }, new Statement { issue = Issue.Business, stance = 0.8f } };
        tweets.Add(tweet9);

        List<string> tweet10 = new List<string>() { "Approximately 9% of unidians are thought to be illegal immigrants", "These people are trying to escape terrible situations or trying to reach opportunities that are otherwise unattainable. We should do our best to aid them here, and aid other countries in making life better for their citizens. #GlobalCommunity", "Think I could get them to vote for me? Might be enough to win me the election. If I lose, we know why! #VoteFor" + firstname, "We cannot allow people to enter and stay in our country illegally. It takes jobs and resources away from our own citizens. We must send them back to wherever they came from and keep them out." };
        List<Statement> w10 = new List<Statement>() { new Statement { issue = Issue.Domestic, stance = -0.4f }, new Statement { issue = Issue.Domestic, stance = 0.1f }, new Statement { issue = Issue.Domestic, stance = 0.8f } };
        tweets.Add(tweet10);

        List<string> tweet11 = new List<string>() { "Anti-abortion rally to be held in Pioucity", "I support allowing women to choose whether they want to carry a baby to term or not. It is not up to lawmakers to decide for them. #TheirChoiceNotOurs", "Damn! I’m holding a rally that day. Think I should reschedule? #SeeMeInstead", "People, institutions, businesses and provinces have their own morals and ideals. We should respect that and allow them to ban things they disagree with. #YouCanAlwaysMove" };
        List<Statement> w11 = new List<Statement>() { new Statement { issue = Issue.Feminism, stance = -0.9f }, new Statement { issue = Issue.Feminism, stance = 0.2f }, new Statement { issue = Issue.Feminism, stance = 0.8f } };
        tweets.Add(tweet11);

        List<string> tweet12 = new List<string>() { "Valkyrias introduces new diversity quota for hiring women, minorities", "Diversity is one of the strengths of our nation, and of our industry. This legislation will benefit all, and hopefully won’t be necessary in the future", "Does this have any restrictions on appearance? I hire plenty of women, but they have to meet my standards! #HirePretty", "This type of law promotes discrimination of white men, and will likely lead to less qualified individuals receiving jobs. Should be removed. #EarnThePosition" };
        List<Statement> w12 = new List<Statement>() { new Statement { issue = Issue.Race, stance = -0.8f }, new Statement { issue = Issue.Feminism, stance = 0.1f }, new Statement { issue = Issue.Race, stance = 0.9f } };
        tweets.Add(tweet12);

        List<string> tweet13 = new List<string>() { "Cannibisia legalizes marijuana, open for growers and sellers", "Marijuana has its benefits and downsides, but is overall safe for general use. Use safely, and have fun! #DontDopeAndDrive", "Isn’t marijuna the drug that makes you crazy? I think we may need to watch out for riots coming from Cannibisia! #DontKillMePlease", "Marijuana has not been studied, and is classified as a very dangerous drug. These people are rushing this legalization!" };
        List<Statement> w13 = new List<Statement>() { new Statement { issue = Issue.Domestic, stance = -0.6f }, new Statement { issue = Issue.Domestic, stance = 0.1f }, new Statement { issue = Issue.Domestic, stance = 0.8f } };
        tweets.Add(tweet13);

        List<string> tweet14 = new List<string>() { "Valkyrias issues new building codes, requires gender-neutral bathrooms", "A great step forward towards inclusivity and making everyone feel comfortable. I believe we can always take more steps to make everyone feel welcome in our country", "We should make ones for lizardmen too. I bet they hate having to use human bathrooms. #Conspiracy #SecretSociety #Puppet", "These rules force new construction projects to spend more money on unnecesary expenses. If you don’t feel comfortable using the public restroom, use the one you have at home!" };
        List<Statement> w14 = new List<Statement>() { new Statement { issue = Issue.Feminism, stance = -0.8f }, new Statement { issue = Issue.Feminism, stance = 0.1f }, new Statement { issue = Issue.Feminism, stance = 0.4f } };
        tweets.Add(tweet14);

        List<string> tweet15 = new List<string>() { "Senate to discuss change in tax code", "Taxes are vital to the survival of our country and the neediest among us. These taxes help our citizens, and require everyone to contribute. I support increased taxes for the rich to increase funding for safety net programs.", "The president doesn’t have to pay taxes, right? So looking forward to that! #WhatTaxForms", "Taxes are a necessary evil, but people deserve to keep their hard-earned money. I support lowering taxes for all, and having a flat tax rate for all people and businesses, regardless of income" };
        List<Statement> w15 = new List<Statement>() { new Statement { issue = Issue.Business, stance = -0.6f }, new Statement { issue = Issue.Business, stance = 0.1f }, new Statement { issue = Issue.Business, stance = 0.8f } };
        tweets.Add(tweet15);

        List<string> tweet16 = new List<string>() { "15% of people earn $13,000 or less a year", "People need to be able to survive on the wage they recieve. I support increases to minimum wage and in funding for federal aid programs", "What jobs pay that little? Those people should try being CEO’s. We make more than that an hour! #GetOnMyLevel", "People are responsible for their own income, and businesses need to be free to run themselves as they see fit. If people are unable to make enough money, they can always get another job or find a better one" };
        List<Statement> w16 = new List<Statement>() { new Statement { issue = Issue.Business, stance = -1f }, new Statement { issue = Issue.Business, stance = 0.3f }, new Statement { issue = Issue.Business, stance = 0.8f } };
        tweets.Add(tweet16);

        List<string> tweet17 = new List<string>() { "New Federal Equal-Pay rules announced", "All people deserve to be paid the same for doing the same work. I support #EqualPayForEqualWork , for all genders, races, sexual orientations", "Do I have to pay my employees the same amount I pay myself? Unfair! I do so much more work sitting in my office than they do in their offices! #SoMuchSigning", "It is not governments place to decide how a business should be run. What do lawmakers know about business decisions? #PresidentNotCEO" };
        List<Statement> w17 = new List<Statement>() { new Statement { issue = Issue.Feminism, stance = -0.8f }, new Statement { issue = Issue.Business, stance = 0.1f }, new Statement { issue = Issue.Business, stance = 0.8f } };
        tweets.Add(tweet17);

        List<string> tweet18 = new List<string>() { "Average student debt has reached $40,000, expected to keep rising", "An educated workforce is a boon for our economy, but massive debts harm these intelligent workers and discourage others. We must take steps to lower the cost of tuition and let more students take these steps to better and more fulfilling jobs", "Student loan debt? Isn’t that what parents are for? Just pay it off already! #SmallLoan", "The government's job is not to be a bank. We have banks for that! The government needs to allow the free market to do its thing and drive down tuition and loan prices through competition." };
        tweets.Add(tweet18);
        List<string> tweet19 = new List<string>() { "Hottest year on record, second year in a row", "We only have one planet, and it is our job to keep that planet livable. As president, I will take steps to slow down and reverse global warming trends", "NICE! I always thought there was too much snow. Now I can play more golf. #GlobalWarmingIsAMyth", "Our climate is changing all the time, regardless of our actions. There is no evidence that the recent warming is due to human activities, or that this trend will reverse naturally in the near future." };
        tweets.Add(tweet19);
        List<string> tweet20 = new List<string>() { "President signs bill to expand oil drilling operations", "Oil and coal are harmful to our planet. We must move away from these energy sources before it is too late! #GlobalWarming", "Try to avoid the warm coastlines! I have a lot of property there, and I don’t want to see its value plummet because of UGLY oil rigs! #ResortLife", "This bill will create many more jobs and expand our economy. It is important that we rely on our own fuel, rather than foreign oil" };
        tweets.Add(tweet20);
        List<string> tweet21 = new List<string>() { "25% of all energy from renewable sources, expected to increase exponentially", "Renewable energy is clean and safe for our environment. We must have a planet for our children to live on in the future #NoFootprint", "Methane is a renewable energy source, right? That comes from FARTS! LOLOLOL #ToiletHumor", "Many people rely on coal and oil for jobs and livelihoods. Switching to these energy sources will take away more jobs, and provide no benefit to us" };
        tweets.Add(tweet21);
        List<string> tweet22 = new List<string>() { "5% of people don’t believe in vaccines, survey says", "Vaccines are an important protection against illnesses. Herd immunity is the only protection some people have! We need to protect them by vaccinating ourselves.", "Needles hurt. OUCH! No vaccine for me, thanks. Can’t they cause mental issues too? #JustWashYourHands", "Sickness is an issue that affects everyone. We must be protected against them for our own wellbeing and for our economy. #NoSickWorkers" };
        tweets.Add(tweet22);
        List<string> tweet23 = new List<string>() { "Prisons are getting overcrowded. What can be done?", "Many people put in prison are put there for small offenses. We should decrease sentences for non-violent offenders who cooperate in prison", "Why do people keep going there? I hear the food is terrible. 0 STARS! #VisitMyResort", "Prisons are expensive to construct and run, and the government doesn’t have the money to spare. We should allow private corporations to run prisons, saving money." };
        tweets.Add(tweet23);
        List<string> tweet24 = new List<string>() { "Foreign aid being sent to Othernia, others", "Helping our allies when they are in need will guarantee we will receive aid should we ever need it. We must continue our aid", "What kind of aid do they need? I could use some Kool-aid! #SendAid", "All the money we send overseas could be used to help our own people. We need to put ourselves first before helping others" };
        tweets.Add(tweet24);
        List<string> tweet25 = new List<string>() { "Unidia considers increasing nuclear bomb count", "We cannot keep increasing our weapons to scare other nations into submission. It is a waste of resources, and only puts the entire world in danger. We need to work towards a peaceful solution when possible", "Sounds good! I’d LOVE to have more bombs at my disposal. #LetThemDrop", "We need to be able to compete militaristically with the rest of the world. If we fall behind, other countries will be able to stomp all over us." };
        tweets.Add(tweet25);
        List<string> tweet26 = new List<string>() { "President considering repeal of net neutrality rules", "Free and open internet is vital to everyone who uses a computer for work and play. To repeal these rules would force people to pay more for services when they don’t need to, so companies can make more profit", "I prefer to keep things net POSITIVE, especially for me. #GiveMeTheMoney", "We believe companies should be able to decide for themselves what the best decisions for their industries are. The government has no right to decide for them" };
        tweets.Add(tweet26);
    }
}
