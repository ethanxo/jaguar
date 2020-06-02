# Jaguar
- Uses $ as a prefix (customizable)
- Only responds on input from logged in client
- Confirms execution (or not) and then deletes your message
- If you're unsure of anything else just look at the code, it's not hard to understand
- I could have made this much more organized and effecient but I just made a shit ton of functions and a switch case because I'm lazy and don't care about this
## Commands
- There's only a few unique commands, the rest just use random APIs I found
### Nuke Token
- Nukes the input token (this is meant to fuck people over, modify it or make a less "heavy" version for normal use
- Enables light theme, compact messages, and changes language to Russian
- Makes their avatar "broke.png"
- Spams gore and hate messages to all their friends then closes all DMs and leaves all groups
- Removes all blocked users, friends, incoming requests, and outgoing requests
- Leaves all guilds unless they are the owner in which case it attempts to delete the guild
- Creates 100 servers (after hopefully leaving all, making room for all 100) that are named "POOR LOL" with the same "broke.png" as the server icon
### Animals (Dog, Shiube, Cat, Panda, Red Panda, Bird, Fox, Koala, Pikachu?)
- Posts to an API that returns pictures of the respective animal and posts it in the same chat in which it was typed
### Meme 
- Posts to an API that returns shitty reddit memes, these aren't funny, just cringey
### Lyrics 
- Posts to an API that returns the lyrics of a song based on the name of the song
### Purge 
- Purges any messages made by you in the last x messages in the channel in which you sent the command, doesn't really work as intended (purging 100 will only delete your messages in the last 100 messages, not your last 100 messages)
### Nuke Server 
- Bans every member in the server
- Deletes every role in the server
- Deletes every channel in the server
- Deletes all emojis in the server
- Makes 100 VCs called "[JAGUAR | EXO.BLACK]"
- I'm pretty sure this isn't functional as is but I'm too lazy to test
