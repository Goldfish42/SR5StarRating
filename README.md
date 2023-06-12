# SR5StarRating

A Synth Riders mod for rating song maps on a 5-star scale [PCVR]

This mod is not yet releasable.  All content here is a preview intended to drive feedback & discussion.

Proposed look-and-feel:
![image](https://github.com/Goldfish42/SR5StarRating/assets/28934930/b1eda88d-49af-4951-aba0-d52a326766ce)

## Purpose
A long time ago, I made it my personal goal to play every custom song available on SynthRiderz.  When this journey began, I simply started recording the names of maps that stood out to me as particularly fun, so I could look them up again when I finished the whole list.  

Eventually, I wanted to distinguish between how much I enjoyed these maps on a variable scale, so I started adding asterisks to differentiate them.  Occasionally, I encountered maps that were challenging in a fun way, but not necessarily up to the quality that I had been rating songs by up to that point.  So I started adding exclamations to denote the physical challenge of the maps.

I found that these two scales really gave me everything I wanted to know about a map.  The first scale informed me as to how much fun & enjoyment I would get from playing the map, and the second scale would inform me if it would be physically easy or challenging.

Some folks have pointed out that my ratings seem to overlap in spirit with the 4-category 5-star song review system on SynthRiderz.  After studying and attempting to incorporate those 4 categories into my rating system, I found that it was too difficult to keep track of my ratings for many songs, and it detracted from my overall game experience.  Ultimately, I believe that review system is intended for a different purpose: to inform mappers directly of players' opinions.  On the other hand, my rating system is intended to remind players of their own opinions, assuming you don't have an eidetic or photographic memory.  They don't call me Goldfish for nothing =)

Some point out the existing Favorites list, or SynthRiderz' Up/Down voting buttons as similar features.  For me, they don't distinguish between enough factors to inform me of my expected experience with a given song (assuming I have it on my Favorites list, and I've upvoted it).

I plan to implement search/sort/filter functionality to provide song matches based on the rating scales in this mod.  Hopefully this can help players to generate better playlists.  Imagine building a session playlist that starts with lower intensity maps and gradually builds up intensity, then modulating between low and high intensities for subsequent maps to give you a challenge and then a chance to recover before the next challenge.  Imagine incorporating a minimum quality rating for these maps.  Imagine generating a randomized playlist using these same criteria each time you play.

## Planned Features
* Independent 5-star ratings for Quality and Intensity
  * Quality is the subjective measure of your own Quality of Experience with the map.  If you enjoy certain styles of maps and you play a map has those factors you enjoy, then you should rate it higher.  You should always think "higher is better" whenever you think of this metric.
  * Intensity is the subjective measure of your Level of Exertion.  If you find the map more physically demanding, then you would rate it higher.  Unlike the Quality metric, higher is not always better with Intensity.  This is up to you, your preferences and your own physical limits.
* Ratings are tied to selected map difficulty (Easy-Master/Custom).  If a map has multiple available difficulties, you can rate them all differently if you choose to.
* Sometimes you can't finish a map or simply choose not to, but you want to rate and remember your limited experience.  If you rate a map but your play count is still 0, those ratings will have a different visual appearance to remind you that you haven't seen the whole map.
* Search/Filter/Sort the song list based on your ratings, in addition to other factors.
