MONSTERS — UNITY URP

CONTENTS

6 animated characters:
Abisal, Cthulhu, Golem, Micelio, Robot and Volcan.

Each character includes:
- Rigged FBX
- 3 animations: Idle, Walk/Swim and Attack
- 64x64 PNG texture
- URP Lit material
- Animator Controller
- Ready-to-use Unity prefab

IMPORT

1. Open a Unity URP project.
2. Go to Assets > Import Package > Custom Package.
3. Import Monsters_URP.unitypackage.
4. Drag any prefab from Assets/Monsters/<character> into your scene.

You can also copy the Assets/Monsters folder directly into your project.
Keep all .meta files to preserve references.

ANIMATOR

Idle
Walk
Swim
Attack

Example:

    animator.SetFloat("Speed", speed);
    animator.SetTrigger("Attack");

TECHNICAL INFO

- Rig: Generic
- Forward: +Z
- Up: +Y
- Approx. height: 2.5 m
- Animations baked at 60 FPS
- Idle and locomotion loop
- Attack does not loop
- Root Motion disabled
- Point-filtered textures
- Bloom can be added with a URP Volume

No gameplay scripts, colliders, sounds, navigation or damage systems are included.

TESTED WITH

Unity 2023.1.22f1
URP 15.0.7

Includes 6 Generic Avatars and 18 animation clips.

Editable Blockbench files for Robot and Volcan are included in the Monsters folder.