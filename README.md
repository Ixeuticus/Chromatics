# Chromatics

####About Chromatics

Chromatics is a plugin for Advance Combat Tracker (ACT) which connects Final Fantasy XIV (FFXIV) with Razer Chroma & Logitech RGB devices to create visual alerts using the devices LED's for various FFXIV & ACT functions.


####Features

* Set a device default color universally while ACT is running.
* Change color of devices when emnity is generated.
* Create alerts when Custom Triggers activate with adjustable rate & speed.
* Create alerts when Timers are triggered.
* Create alerts for recieving chat messages.
* Raid Mode for creating special effects when in Raiding instances.
* Vegas Mode for Gold Saucer.
* Device manager to enable/disable devices in ACT (partially implemented).


####Device Compatibility

**Razer Chroma**
* BlackWidow Chroma
* BlackWidow TE Chroma
* DeathAdder Chroma
* DeathStalker Chroma (Partial)
* Diamondback (Partial)
* Firefly
* Kraken 7.1 Chroma
* Mamba TE Chroma
* Orbweaver Chroma
* Tartarus Chroma

**Logitech RGB**
* G910 Orion Spark
* G710+
* G633 & G933
* G600
* G510/G510s
* G110
* G19/G19s
* G105
* G105 COD
* G300
* G303 Daedalus Apex
* G11
* G13
* G15

*Please note: Logitech RGB devices are untested at this current point in time*


####Prerequisites

* [Advance Combat Tracker](http://advancedcombattracker.com/) with FFXIV Plugin
* [Razer SDK](http://www.razerzone.com/au-en/synapse) (Automatically installed with Razer Synapse)
* .Net Framework 4.5 (Full)


####Installation

1. Download the [latest version](https://github.com/roxaskeyheart/Chromatics/releases) of Chromatics.
2. Unzip and copy the folder to your ACT installation directory. (C:\Program Files (x86)\Advanced Combat Tracker)
3. Turn on Chroma Apps in Razer Synapse (Synapse > Chroma Apps > Enable).
4. Open Advance Combat Tracker.
5. Open the Plugins tab.
6. Browse to your ACT installation directory and select the Chromatics.dll in the Chromatics folder.
7. Select Add/Enable Plugin.
8. A new Chromatics tab will appear, select this to customize settings.


####FAQ

Q: How do I find out if my device is compatible with Chromatics?
A: You can find a list of currently supported devices above under Device Compatibility.

Q: Do you plan to add support for other RGB devices outside of Razer Chroma and Logitech RGB?
A: I am currently planning on adding Corsair keyboards in a futre release and potentially more if demand is high.

Q: Is there a 32-bit version of Chromatics available?
A: Unfortuantely there is not a 32-bit version available due to device limitations. I am currently investigating this further.

Q: I added the plugin to ACT and it shows an error message or crashes ACT.
A: Make sure you have the latest versions of Razer Synapse, ACT and the FFXIV ACT Plugin installed on your computer before running Chromatics. Also check that you are running a 64-bit Operating System. Restarting ACT has also been known to fix errors similar to this. If you continue to have problems, please submit a [bug report](https://github.com/roxaskeyheart/Chromatics/issues) with your ACT log.

Q: When setting up chat notifications, I get notified when I send a message as well as when I recieve one. Can I set it to only notify me when I receive a message?
A: This is currently a limitation of the FFXIV Parsing plugin. I am currently investigating to add this functionality in a future release.

Q: The Device controls don't work or only partially work correctly.
A: The Device manager is only partially implemented as of 1.0.x. There will be bugs in using it which will be resolved in a future patch.

Q: 
A:

####Known Issues

* Device selection only partially implemented.
* An issue in which plugin may cause ACT to crash if plugin is removed and re-added to ACT without restarting ACT in-between.
* Untested on Logitech RGB devices.