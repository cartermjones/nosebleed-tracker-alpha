# nosebleed-tracker-alpha
Alpha version of a Nosebleed Tracker web application, designed to help people with HHT and/or chronic nosebleeds track and analyze trends in their nosebleeds. The Alpha version can currently log and manage nosebleed events for a single user, and now supports the ability to display a rudimentary report detailing the average severity of bleed events in the database and the number of bleeds in the current month.

## Features and Use
The TOBIAS Nosebleed Tracker, as it is lovingly called, currently allows the user to view logged nosebleed events, log new bleeds, and delete bleeds from the log. Bleeds are logged according to severity (on a scale of 1-10), and the user can leave a comment about the bleed event if they so desire. The user is required to log a date and time for the bleed as well (otherwise the database becomes very, very unhappy). <br /><i>Note: In the current version, there is a Reports link in the navbar that directs users to a page displaying a rudimentary report. This is not reflected below.</i><br />

![Nosebleed Tracker Screenshot](/tracker-screenshot.png)

## About the Database
The database I've decided to use for this project is MySQL. The database can be interfaced with by using the following stored procedures:

1.) <code>spGetAllBleedsChronologicalDescending()</code> - fetches all the bleeds in the database in descending chronological order.<br />
2.) <code>spLogBleed(Severity, Comment, BleedDateTime, Duration)</code> - used for logging a new bleed. <br />
3.) <code>spDeleteBleed(BleedId)</code> - deletes the specified bleed. (In production, this stored procedure will be modified to be less... dangerous. Right now it is a very, <i>very</i> hard delete.) <br />
4.) <code>spAverageSeverity</code> - pulls the average severity of all bleeds in the database. <br />
5.) <code>spThisMonthBleedFrequency</code> - pulls the number of bleeds for the current month. <br />

This is tailored for MySQL, but if you're using another relational database (such as MS SQL Server), the tweaking required to make it work should be minimal.

## About HHT
Hereditary Hemorrhagic Telangiectasia (HHT) is an uncommon genetic bleeding disorder - it is characterized by arteriovenous malformations (AVMs) across the body, both internally and externally. One of the most common symptoms of HHT is chronic nosebleeds (although this is not universal), which can range in severity from a minor inconvenience to a major bleed requiring hosptilization and blood transfusions.  

Beyond nosebleeds, people with HHT can suffer from internal bleeding, bleeding from the throat, or spontaneous bleeding from any of the AVMs on their skin. Patients with HHT tend to be at a higher risk for stroke, and there are many precautions that must be taken by people with HHT for even routine medical care. (E.g., someone with HHT shouldn't get their teeth cleaned at the dentist without taking a round of antibiotics in order to prevent brain infections associated with brain AVMs.) 

## Other Details
This project is being built using C#, .NET Core, MySQL, and it uses MVC architecture. It is very much a work in progress, but it is a labor of love. My wife, whom I love, has HHT, and I wanted to make something that might be of use to her.  

More information about HHT can be found at https://curehht.org/understanding-hht/. Many people who have HHT are currently undiagnosed, and proper diagnosis could save lives. 

Be well, and happy coding!
