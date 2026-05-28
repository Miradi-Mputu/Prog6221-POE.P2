using System;
using System.Collections.Generic;

namespace CyberBotGUI
{
    public class ChatEngine
    {
        // Stores the user's name for personalised responses
        public string UserName { get; set; } = "";

        // Random number generator for picking random responses
        public Random Rng = new Random();

        // Remembers the last topic the user asked about (for "tell me more")
        public string LastTopic = "";

        // Response database - each topic has one detailed response
        public Dictionary<string, string> Responses = new()
        {
            ["password"] = "Strong passwords use 12+ characters with uppercase, lowercase, numbers, and symbols. Example: $uN#8kPz!mQ2@. Never reuse passwords. Use a passphrase like My#Cat@Eats2Fish. A password manager stores all your passwords safely.",

            ["phishing"] = "Phishing is when scammers send fake emails pretending to be trusted companies. Look for urgent language, spelling mistakes, and suspicious links. Never click links in suspicious emails. Your bank will never ask for your password by email.",

            ["safe browsing"] = "Always look for https and a padlock icon in the address bar before entering passwords or credit cards. Avoid pop-up ads that say 'You've won!' Keep your browser updated for security fixes.",

            ["two factor"] = "Two-factor authentication (2FA) adds a second login step. Even if someone steals your password, they still need the code from your phone. Enable 2FA on email and banking accounts.",

            ["malware"] = "Malware is harmful software that damages your device or steals information. Types include viruses, trojans, and spyware. Install antivirus software and keep it updated. Never open attachments from unknown senders.",

            ["ransomware"] = "Ransomware locks your files and demands money to unlock them. Never open unexpected attachments. Back up your files regularly to an external drive or cloud storage.",

            ["firewall"] = "A firewall monitors your internet traffic and blocks suspicious connections. Windows and macOS have built-in firewalls. Make sure yours is turned on, especially on public Wi-Fi.",

            ["vpn"] = "A VPN encrypts your internet traffic and hides your online activity. This is important on public Wi-Fi. Be careful with free VPNs - they often sell your data. Choose a reputable paid VPN.",

            ["social engineering"] = "Social engineering tricks people into giving away information by manipulating emotions like fear or urgency. Always verify who you're talking to. If something feels wrong, hang up and call the official number.",

            ["data breach"] = "A data breach happens when hackers steal user information from a company. Check haveibeenpwned.com to see if your email was exposed. Use unique passwords for every account.",

            ["encryption"] = "Encryption scrambles your data so only authorised people can read it. Your password is encrypted before being sent online. WhatsApp and Signal use end-to-end encryption for messages."
        };

        // Extra tips for follow-up questions
        public Dictionary<string, List<string>> ExtraTips = new()
        {
            ["password"] = new List<string> {
                "Never write passwords on sticky notes!",
                "Change important passwords every 3-6 months.",
                "Don't use the same password for multiple sites."
            },
            ["phishing"] = new List<string> {
                "Always check the sender's email address carefully.",
                "Forward suspicious emails to report@phishing.gov.uk",
                "Hover over links before clicking to see the real address."
            },
            ["malware"] = new List<string> {
                "Keep your operating system updated for security patches.",
                "Be careful with USB drives from unknown sources.",
                "Use a standard user account instead of admin for daily tasks."
            }
        };

        // Empathetic responses for user emotions
        public Dictionary<string, string> SentimentResponses = new()
        {
            ["worried"] = "I understand you are worried. ",
            ["scared"] = "No need to panic. ",
            ["confused"] = "Let me explain clearly. ",
            ["frustrated"] = "I understand your frustration. ",
            ["curious"] = "Great question! ",
            ["nervous"] = "It's okay to feel nervous. "
        };

        // Detects topic from user input by checking for keywords
        public string GetTopic(string input)
        {
            // Check for follow-up questions first
            if (input.Contains("tell me more") || input.Contains("explain more"))
                return "tellmemore";

            if (input.Contains("another tip"))
                return "anothertip";

            // Check for main cybersecurity topics
            if (input.Contains("password")) return "password";
            if (input.Contains("phishing")) return "phishing";
            if (input.Contains("safe browsing")) return "safe browsing";
            if (input.Contains("two factor") || input.Contains("2fa")) return "two factor";
            if (input.Contains("malware")) return "malware";
            if (input.Contains("ransomware")) return "ransomware";
            if (input.Contains("firewall")) return "firewall";
            if (input.Contains("vpn")) return "vpn";
            if (input.Contains("social engineering")) return "social engineering";
            if (input.Contains("data breach")) return "data breach";
            if (input.Contains("encryption")) return "encryption";

            // Check for general commands
            if (input.Contains("how are you")) return "howareyou";
            if (input.Contains("purpose") || input.Contains("what can you do")) return "purpose";
            if (input.Contains("my name is")) return "setname";
            if (input.Contains("menu") || input.Contains("topics")) return "menu";
            if (input.Contains("exit") || input.Contains("quit") || input.Contains("bye")) return "exit";

            return "unknown";
        }

        // Detects emotions in user input and returns an empathetic response
        public string DetectSentiment(string input)
        {
            foreach (var emotion in SentimentResponses)
            {
                if (input.Contains(emotion.Key))
                    return emotion.Value;
            }
            return "";
        }

        // Returns a random extra tip for follow-up questions
        public string GetExtraTip(string topic)
        {
            if (ExtraTips.ContainsKey(topic) && ExtraTips[topic].Count > 0)
            {
                return ExtraTips[topic][Rng.Next(ExtraTips[topic].Count)];
            }
            return "";
        }

        // Main method - takes user input and returns bot's response
        public string GetReply(string rawInput)
        {
            // Convert to lowercase and remove extra spaces
            string input = rawInput.ToLower().Trim();

            // Handle empty input
            if (string.IsNullOrWhiteSpace(input))
                return "Please type something so I can help you.";

            // Detect topic and sentiment
            string topic = GetTopic(input);
            string sentiment = DetectSentiment(input);

            // Show menu
            if (topic == "menu")
                return GetTopicList();

            // Exit the program
            if (topic == "exit")
                return "exit";

            // Respond to "how are you"
            if (topic == "howareyou")
                return "I'm running smoothly and ready to help you stay safe online! What would you like to learn about?";

            // Respond to "what is your purpose"
            if (topic == "purpose")
                return "I'm Cyber Bot - your personal online safety guide. Ask me about passwords, phishing, malware, or any cybersecurity topic!";

            // Save user's name when they say "my name is X"
            if (topic == "setname")
            {
                int nameStart = input.IndexOf("my name is") + "my name is".Length;
                string newName = rawInput.Substring(nameStart).Trim().TrimEnd('.');

                if (!string.IsNullOrWhiteSpace(newName))
                {
                    // Capitalise first letter of name
                    UserName = char.ToUpper(newName[0]) + newName.Substring(1);
                    return "Nice to meet you, " + UserName + "! What cybersecurity topic would you like to learn about?";
                }
                return "I didn't catch your name. Please say: my name is [your name].";
            }

            // Handle follow-up questions like "tell me more" or "another tip"
            if (topic == "tellmemore" || topic == "anothertip")
            {
                if (!string.IsNullOrEmpty(LastTopic) && Responses.ContainsKey(LastTopic))
                {
                    string extraTip = GetExtraTip(LastTopic);
                    if (!string.IsNullOrEmpty(extraTip))
                    {
                        return extraTip + " Want another tip? Just say 'another tip' or type 'menu' for more topics.";
                    }
                    else
                    {
                        return Responses[LastTopic] + " That's all I have on " + LastTopic + ". Type 'menu' for more topics.";
                    }
                }
                else
                {
                    return "Please ask about a topic first, like 'phishing' or 'passwords', then I can tell you more.";
                }
            }

            // Handle main topic responses (passwords, phishing, malware, etc.)
            if (Responses.ContainsKey(topic))
            {
                // Remember this topic for follow-up questions
                LastTopic = topic;

                // Add user's name occasionally (30% chance for personalisation)
                string namePrefix = "";
                if (!string.IsNullOrWhiteSpace(UserName) && Rng.Next(3) == 0)
                {
                    namePrefix = "Good question, " + UserName + "! ";
                }

                // Build the final response
                return namePrefix + sentiment + Responses[topic] + " Type 'menu' for all topics, or say 'tell me more' for extra tips.";
            }

            // If user showed emotion but no specific topic was detected
            if (!string.IsNullOrEmpty(sentiment))
            {
                return sentiment + "Type 'menu' to see topics I can help with, or ask about 'phishing' or 'passwords' for cybersecurity tips.";
            }

            // Default response for unrecognized input
            return "I didn't understand that. Type 'menu' to see what I can help with, or try a topic like 'phishing' or 'malware'.";
        }

        // Returns the list of all available topics
        public string GetTopicList()
        {
            return "=== CYBER BOT MENU ===\n\n" +
                   "1. passwords\n" +
                   "2. phishing\n" +
                   "3. safe browsing\n" +
                   "4. two factor (2FA)\n" +
                   "5. malware\n" +
                   "6. ransomware\n" +
                   "7. firewall\n" +
                   "8. vpn\n" +
                   "9. social engineering\n" +
                   "10. data breach\n" +
                   "11. encryption\n" +
                   "Type any topic above to learn more!\n" +
                   "You can also say: 'tell me more', 'another tip', or 'exit'";
        }
    }
}