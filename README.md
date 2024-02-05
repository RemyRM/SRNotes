![SRNotes logo](https://github.com/RemyRM/SRNotes/blob/main/SRNotes/Resources/SRNotesBanner1280x640.png)

# SRNotes
SRNotes is a note-displaying tool that enables users to scroll through text without needing to focus on the application, thanks to user-defined shortcuts. This feature is particularly valuable when playing games that lack proper windowed support, hijack the mouse, or pause when the game loses focus, thus eliminating the need for players to set up additional hardware solely for note-keeping.
For a quick demo check out [this youtube video](https://www.youtube.com/watch?v=TytWDZS--gE)!

The tool can be customised to your needs through the menu bar or [`settings.ini`](https://github.com/RemyRM/SRNotes/blob/main/SRNotes/Resources/Settings.ini) file directly to control:
- The colours of the application
- The font size
- The keybinds used for scrolling
- The method of scrolling
- The speed of scrolling
- Amount of headlines above the current line
- Highlighting the current line

# Usage
## Setting up
Download the installer from the [releases tab](https://github.com/RemyRM/SRNotes/releases) or clone the respository and build the application yourself.

On first time use you will likely want to edit some of the settings. To do this:
- Click "Settings" at the top and use the UI to edit settings
OR
- Click "open settings"
This will open the Settings.ini file (Located in your appdata/roaming folder) in your default text editor.
By default the scroll keys are set to PageUp and PageDown. It is recommended to set a keybind for scrolling that is not used within your game.

**Note:** After editing settings the application needs to be **restarted** manually for the changes to take effect.

## Using the app
Open the .txt file containing your notes:
- Click "File" at the top
- Click "Open File"
- Select your TXT file

Open your game and press your keybinds to scroll through the text.

**Note:**
- The application ignores the position of the caret set by the user through clicking within the text. This means that if you click on for example line 50 to place the caret, pressing your scroll down key will jump back to where the caret was after the last scroll action.
- Having Windows focus on SRNotes may result in weird scrolling operations when using keybinds that are by default used within Windows to scroll textboxes (e.g. arrow down, Page Down etc). If this happens make sure to not have SRNotes as the focused window.


# Commands
Commands are "snippets" encapsulated in [ and ] that tells the application to perform certain actions. Some require, or have optional, parameters that can be passed inbetween ( and ).
Currently the following commands have been implemented:
- `[LoadImage("<Full image path>")]` Loads an image at default Width*Height (supports BMP, GIF, EXIF, JPG, PNG, and TIFF files)
- `[LoadImage("<Full image path>", Width, Height)]` Loads an image at supplied Width*Height (supports BMP, GIF, EXIF, JPG, PNG, and TIFF files)
- `[UnloadImage()]` Unload the image window, this is not necessary after every image load as a new `LoadImage` will override its previous image

## Command examples
- `[LoadImage("C:\data\Dasher.jpg")]` - Loads the image "Dasher.jpg" from the specified path using the images native width and height.
- `[LoadImage("C:\data\Dasher.png", 500, 500)]` - Load the image "Dasher.png" from the specified path using the supplied width and height.

# Issues
If experience any issues with the tool, or would like to suggest a new feature please create an [issue on github](https://github.com/RemyRM/SRNotes/issues), or reach out to me on Discord (RemyM#8070).
