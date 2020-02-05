# nosebleed-tracker-alpha
Alpha-1 version of a Nosebleed Tracker web application, designed to help people with HHT and/or chronic nosebleeds track and analyze trends in their nosebleeds. The Alpha version will be able to log and manage nosebleed events for a single user, and will have no analytics features so far. Analytics/reporting will be built into later versions. 

## Features and Use
The TOBIAS Nosebleed Tracker, as it is lovingly called, currently allows the user to view logged nosebleed events, log new bleeds, and delete bleeds from the log. Bleeds are logged according to severity (on a scale of 1-10), and the user can leave a comment about the bleed event if they so desire. The user is required to log a date and time for the bleed as well (otherwise the database becomes very, very unhappy).

![Nosebleed Tracker Screenshot](/tracker-screenshot.png)

## About the Database
The database I've decided to use for this project is MySQL. The database table is called 'bleeds,' and has four fields: BleedId, Severity, Comment, and BleedDateTime. The primary key is BleedId. From this information, you can generate your own database and table to interface with the web application. This is tailored for MySQL, but if you're using another relational database (such as MS SQL Server), the tweaking required to make it work should be minimal.

## About HHT
Hereditary Hemorrhagic Telangiectasia (HHT) is an uncommon genetic bleeding disorder - it is characterized by arteriovenous malformations (AVMs) across the body, both internally and externally. One of the most common symptoms of HHT is chronic nosebleeds (although this is not universal), which can range in severity from a minor inconvenience to a major bleed requiring hosptilization and blood transfusions.  

Beyond nosebleeds, people with HHT can suffer from internal bleeding, bleeding from the throat, or spontaneous bleeding from any of the AVMs on their skin. Patients with HHT tend to be at a higher risk for stroke, and there are many precautions that must be taken by people with HHT for even routine medical care. (E.g., someone with HHT shouldn't get their teeth cleaned at the dentist without taking a round of antibiotics in order to prevent brain infections associated with brain AVMs.) 

## Other Details
This project is being built using C#, .NET Core, MySQL, and it uses MVC architecture. It is very much a work in progress, but it is a labor of love. My wife, whom I love, has HHT, and I wanted to make something that might be of use to her.  

More information about HHT can be found at https://curehht.org/understanding-hht/. Many people who have HHT are currently undiagnosed, and proper diagnosis could save lives. 

Be well, and happy coding!
