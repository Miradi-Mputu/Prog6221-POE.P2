# Cyber Bot - Cybersecurity Awareness Chatbot
# Part Two 
## Description
Cyber Bot is a Windows desktop chatbot that educates users about cybersecurity threats and best practices. Built with WPF and C#, it provides an interactive way to learn about online safety through conversation.

## Features

- Audio greeting that plays when the application starts
- Visual logo displayed on the launch screen
- Personalised experience that asks for and remembers the user's name
- Typewriter effect that makes bot responses appear one character at a time
- Topic menu that lists all available cybersecurity topics
- Random responses that give different answers for the same topic
- Sentiment detection that responds empathetically when users express worry or confusion
- Follow-up questions that support "tell me more" and "another tip" commands

## Cybersecurity Topics Covered
- Passwords and password safety
- Phishing scams and how to spot them
- Safe browsing habits
- Two Factor Authentication (2FA)
- Malware and its different types
- Ransomware attacks
- Firewall protection
- VPN and private browsing
- Social engineering tactics
- Data breaches
- Encryption and data protection

## How to Use
Launch the application and the welcome sound will play automatically.
Enter your name in the text box and click "Start Chatting" or press Enter.
Type any topic from the menu to learn about it.
Use follow-up commands like "tell me more" or "another tip" for additional information.
Type "exit", "quit", or "bye" to close the application.

## Example Interaction
Bot: Welcome, John! I am Cyber Bot, your personal online safety guide.

Bot: === CYBER BOT MENU ===

1. passwords
2. phishing
3. safe browsing
4. two factor (2FA)
5. malware
6. ransomware
7. firewall
8. vpn
9. social engineering
10. data breach
11. encryption

Type any topic above to learn more!

You: passwords

Bot: Good question, John! Strong passwords use 12 or more characters with uppercase, lowercase, numbers, and symbols. Example: $uN#8kPz!mQ2@. Never reuse passwords on different websites. Use a passphrase like My#Cat@Eats2Fish. A password manager stores all your passwords safely. Type 'menu' for all topics, or say 'tell me more' for extra tips.

You: tell me more

Bot: Never write passwords on sticky notes! Want another tip? Just say 'another tip' or type 'menu' for more topics.

You: exit

Bot: Goodbye, John! Stay safe online.


## Project Structure
The AudioPlayer folder contains the greeting.wav sound file.
The Image folder contains the Logo.png image file.
AudioPlayer.cs handles all audio playback functionality.
ChatEngine.cs contains the bot logic, responses, and topic detection.
MainWindow.xaml defines the user interface layout.
MainWindow.xaml.cs handles UI events and display logic.
App.xaml is the application definition file.
AssemblyInfo.cs contains assembly metadata.

## YouTube 
Click here to watch the demo video: https://youtu.be/spc2_NHJuKQ

## Commit History
Initial commit: Set up WPF project structure and files.
Added AudioPlayer class with greeting sound functionality.
Added ChatEngine with response dictionary and topic detection.
Added MainWindow UI with name entry and chat screens.
Added typewriter effect for bot responses.
Added sentiment detection and empathetic responses.
Added follow-up commands for tell me more and another tip.
Added logo image and finalised UI styling.
