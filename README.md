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

# Building
If you download the source you can either build the application directly using Visual Studio and run the resulting exe. Or build the `SRNotesSetup` project and run the resulting setup.exe.
When downloading the prebuild binaries all you have to do is run `setup.exe` which will also download all prerequisites and dependencies (such as .NET Framework 4.8.1)

# Issues
If experience any issues with the tool, or would like to suggest a new feature please create an issue on github, or reach out to me on Discord (RemyM#8070).

![SRNotes logo](https://github.com/RemyRM/SRNotes/blob/main/SRNotes/Resources/Icon256x256.png)