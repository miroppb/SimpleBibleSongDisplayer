## SimpleBibleSongDisplayer2

This application is meant to be used to churches or really any place that can benefit from it. I created this application for my church, back when  we were using SoftProjector, but wanted something with more features. We then started using EasyWorship, so I didn't work on it much, but I still use it during our video streams.

Application does:
1. Reads .xml file with lines of text. Recommend using something like
```
<verse>
	<book>Бытие 1:1</book>
	<verse_text>В начале сотворил Бог небо и землю.</verse_text>
</verse>
```

2. Searches by book title.
    * Search with spaces
    * ie. Luke 4 1 will look for Luke 4:1
        * 2Kings 5 5 works too
    * Search parameters can be adjusted as needed (2nd box)
3. Double-click verse/text to add to schedule
    * Double-click from schedule to search for said verse/text
    * Right click once to edit
4. Add "Speaker" or non-bible text.
    * Speaker text is added to Live Schedule when double-clicked on
5. Items in schedule can be rearranged by dragging.
    * Press Delete to remove item
6. Press Show to show a second window with the actual text.
    * Live Schedule is shown on right
    * Clicking item advances to that verse/text
    * Click up or down arrows (beside Live) to make verse text size larger or smaller
    * Pressing a number will move the selection up by that amount. ie. Press 4 to move up 4 items.
7. API Server exists
    * Allows practically all functions available on main layout
        * Go Live
        ```
        /api/go
        ```
        * Search for text
        ```
        /api/search/text
        ```
        * When searching, select verse
        ```
        /api/setverseitem/index
        ```
        * Select item on schedule
        ```
        /api/setscheduleitem/index
        ```
        * Select item on Live Schedule
        ```
        /api/setshowitem/index
        ```
    * Port 1111
        * Make sure you open firewall, to be able to connect from other devices
8. Ability to "process" a text file
    * Go through a text file of lyrics, and add to an .xml file that can be used by the application
9. Ability to save songs to a database, to be easily located and re-added to a schedule.
    * Either process an .xml to a database, or Cancel to view songs already in database.
    * Still finicky at times

#StopWarInUkraine