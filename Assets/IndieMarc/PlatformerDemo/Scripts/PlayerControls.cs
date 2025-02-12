using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player controls for platformer demo
/// Author: Indie Marc (Marc-Antoine Desbiens)
/// </summary>

namespace IndieMarc.Platformer
{

    public class PlayerControls : MonoBehaviour
    {
        public int player_id;
        public KeyCode left_key;
        public KeyCode right_key;
        public KeyCode up_key;
        public KeyCode down_key;
        public KeyCode jump_key;
        public KeyCode action_key;

        public AudioSource walkClip;  // ลากไฟล์เสียงเดินมาใส่ใน Inspector
        public AudioSource jumpClip;  // ลากไฟล์เสียงกระโดดมาใส่ใน Inspector

        private Vector2 move = Vector2.zero;
        private bool jump_press = false;
        private bool jump_hold = false;
        private bool action_press = false;
        private bool action_hold = false;

        private AudioSource audioSource;

        private static Dictionary<int, PlayerControls> controls = new Dictionary<int, PlayerControls>();

        void Awake()
        {
            controls[player_id] = this;
            audioSource = GetComponent<AudioSource>();
        }

        void OnDestroy()
        {
            controls.Remove(player_id);
        }

        void Update()
        {
            move = Vector2.zero;
            jump_hold = false;
            jump_press = false;
            action_hold = false;
            action_press = false;

            bool isWalking = false;

            if (Input.GetKey(left_key))
            {
                move += -Vector2.right;
                isWalking = true;
            }
            if (Input.GetKey(right_key))
            {
                move += Vector2.right;
                isWalking = true;
            }

            if (Input.GetKey(up_key)) move += Vector2.up;
            if (Input.GetKey(down_key)) move += -Vector2.up;

            if (Input.GetKey(jump_key)) jump_hold = true;
            if (Input.GetKeyDown(jump_key))
            {
                jump_press = true;
                jumpClip.Play(); // เล่นเสียงกระโดด
            }

            if (Input.GetKey(action_key)) action_hold = true;
            if (Input.GetKeyDown(action_key)) action_press = true;

            float move_length = Mathf.Min(move.magnitude, 1f);
            move = move.normalized * move_length;

            // เล่นเสียงเดิน
            if (isWalking && !audioSource.isPlaying)
            {
                walkClip.Play();
            }
        }

        private void PlaySound(AudioClip clip)
        {
            if (clip != null && audioSource != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }

        public Vector2 GetMove()
        {
            return move;
        }

        public bool GetJumpDown()
        {
            return jump_press;
        }

        public bool GetJumpHold()
        {
            return jump_hold;
        }

        public bool GetActionDown()
        {
            return action_press;
        }

        public bool GetActionHold()
        {
            return action_hold;
        }

        public static PlayerControls Get(int player_id)
        {
            foreach (PlayerControls control in GetAll())
            {
                if (control.player_id == player_id)
                {
                    return control;
                }
            }
            return null;
        }

        public static PlayerControls[] GetAll()
        {
            PlayerControls[] list = new PlayerControls[controls.Count];
            controls.Values.CopyTo(list, 0);
            return list;
        }
    }
}