# ProjectEsky-UnityIntegration

Welcome to Project Esky! 

Project Esky aims to be the software companion to allow developing with the Deck X/North Star Display system out of the box! 
(Utilizing the Intel Realsense t265/1 or a ZED system for 6DoF tracking <Available in another repo, TBA>)
This includes a unity package that handles
- Rendering (with V2)
- MRTK Integration with the Leap Motion controller (aligned with the user's view)
- 6DoF Head Tracking + Re-Localization events (Save map, load map, add persistence, callbacks, ect.)
- Spatial mapping (Via the ZED SDK, with future plans to rip out the point cloud for t265 to allow scene authoring/phantom model interactions)
- Object Persistence (Via the t265/1 or ZED SDK <Available in another repo, TBA>)

This channel is dedicated to those who want to use esky in their projects, however if you do use this for research purposes, we kindly ask you to cite the following paper: <TBA>

Currently, the v2 + leapmotion + T265 calibration in this project has been pre calibrated and setup, 
It utilizes a DeckX variation of the Project North-Star display, purchasable here: https://www.smart-prototyping.com/AR-VR-MR-XR 
Your headset, provided there is little warping in the 3D print/sensor arrangement, should be good to go from here!

If you want to improve the visual quality, calibrate your NS using the v2 method described here: https://project-north-star.gitbook.io/project-north-star/calibration/calibration-v2

Copy/Paste the 4 float arrays generated by the northstar v2 calibration, into /NorthStarCalibration.json
(Warning, DO NOT JUST COPY AND PASTE THE FILE, or you'll need to re-add the extra variables I set, at least until the calibration method includes these variables in the JSON file)

Load up the project in unity, load /Assets/HandInteractionExamples.unity

Adjust the NorthStarV2NativeRenderer script attached to the 'NorthStarRig' gameobject with the window position x/y, and resolution of your render textures
if your image isn't clear, try toggling the 'requires rotation' boolean (to rotate the cameras 90 degrees)
with any luck you, when you hit play, you should see an undistorted stereo pair on your headset.

You can now adjust the offset for the left and right eye, using the NorthStar V2 Native Renderer, 
you should try your best to adjust the offsets so that the objects in the scene overlap perfectly!

<TODO: A scene specifically for screen-space alignment>
<TODO: Instructions for hand alignment, and save left/right eye offsets in the calibration file>
<TODO: Native intergration of the ZED tracker, either as a source for pose input, or 3D reconstruction>
<TODO: Add instructions for relocalization>
<TODO: Integrate stabilizer, it's working but buggy due to tracker jitter>

KNOWN ISSUES:
- The relocalizer is known to be a bit finnicky, try reloading the map onto the t265

KNOWN LIMITATIONS:
- The project is limited to the OpenGL rendering backend

If you wish to ask questions, please join the North Star Community on Discord! 
https://discord.gg/fPza2G


Quick FAQ:

1) Hey, I see some extra glsl shaders in the root directory, what are these for?
Actually these are what powers the magic behind the V2 renderer system, I am passing a render texture pointer to a separate OpenGL instance! Allowing for realtime updates and undistortion! (And is what will allow the stabilization techniques later, stay tuned ;) )

2) Wait, does that mean I can use _any_ headset?
YOU ARE GOSH DARN RIGHT!
By editing the vertex and fragment shaders, (or heck, even the OpenGL instance!) you can use _any_ headset.
Alternatively you could replace the cameras in the unity scene with any renderer, steamVR, ect. and still utilize the leapmotion MRTK integration esky provides!

3) Wait, edit an opengl renderer?
You mean to tell me there's moar sauce??
Dang Right!, Look here: https://github.com/HyperLethalVector/ProjectEskyLLAPI
<Project currently empty due to dependency issues>

THIS CODE IS LICENSED UNDER THE 3 CLAUSE BSD LICENSE.

While I don't really give a fuck where and how you use this software, with great power comes great responsibility.
That being said, this is only under one condition, that you cite the following paper:
<Bibtex yet to be added, paper is waiting to release>
<https://www.researchgate.net/publication/344337571_Project_Esky_Enabling_High_Fidelity_Augmented_Reality_Content_on_an_Open_Source_Platform>

If you're looking to contribute, feel free to fork! 

Finally, I always welcome requests for help/collaborations, especially if you're building fun shit! Seek me out :D 
