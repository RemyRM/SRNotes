# SRNotes
SRNotes is a note *displaying* tool that does not require focus to scroll through them using user-defined shortcuts.
This comes in handy when you are playing a game that has no (proper) windowed support, or hijacks the mouse so that you can not move it outside of the game borders to scroll through your notes manually forcing the player to set up additional hardware just for note keeping.

The tool can be customised to your needs through the `settings.ini` file to control:
- The colours of the application
- The font size
- The keybinds used for scrolling
- The method of scrolling
- The speed of scrolling
- Amount of headlines above the current line
- Highlighting the current line

The tool works by directly calling the `GetAsyncKeyState` function from Winuser.h and manipulating the scrollbar through `SendMessage` in combination with `VM_VSCROLL`

# Usage
On first time use you will likely want to edit some of the settings. To do this:
- Click "Settings" at the top
- Click "open settings"
This will open the Settings.ini file (Located in your appdata/roaming folder) in your default text editor.
Here you will find all of the above mentioned settings. It is recommended to set a keybind for scrolling that is not used within your game.

After editing settings the application needs to be **restarted**

Open the .txt file containing your notes:
- Click "File" at the top
- Click "Open File"
- Select your TXT file

Open your game and press your keybinds to scroll through the text.

**Note:**
- The application ignores the position of the caret set by the user through clicking within the text. This means that if you click on line 50 to place the caret, pressing your scroll down key will jump back to where the caret was after the last scroll action.
- Having Windows focus on SRNotes may result in weird scrolling operations when using keybinds that are by default used within Windows to scroll textboxes (e.g. arrow down, Page Down etc). If this happens make sure to not have SRNotes as the focused window.

# Building
Go to the "Releases" tab and download the latest release. This will include `setup.exe` which you can run to install the program. This will also download all prerequisites and dependencies (such as .NET Framework 4.8.1)

If you fork or download the full source you can either build the application directly using Visual Studio and run the resulting exe. Or build the `SRNotesSetup` project and run the resulting setup.exe.

# Issues
If experience any issues with the tool, or would like to suggest a new feature please create an issue on github, or reach out to me on Discord (RemyM#8070).

![SRNotes logo](https://github.com/RemyRM/SRNotes/blob/main/SRNotes/Resources/Icon256x256.png)