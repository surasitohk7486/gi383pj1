using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileShooter : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float minShootForce = 5f;
    public float maxShootForce = 20f;
    public float chargeTime = 2f;

    [Header("UI Settings")]
    public Slider powerSlider;

    [Header("Animation Settings")]
    public Animator animator; // Drag your Animator here in the Inspector

    private float currentChargeTime;
    private bool isCharging;
    private SpriteRenderer playerSprite;

    void Start()
    {
        // Initialize slider
        if (powerSlider != null)
        {
            powerSlider.minValue = minShootForce;
            powerSlider.maxValue = maxShootForce;
            powerSlider.value = minShootForce;
        }

        playerSprite = GetComponent<SpriteRenderer>();

        // Initially hide the slider
        if (powerSlider != null)
        {
            powerSlider.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        HandleCharging();
        FlipShootPoint();
    }

    void HandleCharging()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isCharging = true;
            currentChargeTime = 0f;

            // Show slider when charging starts
            if (powerSlider != null) powerSlider.gameObject.SetActive(true);

            // Play charge animation
            if (animator != null) animator.SetBool("IsCharging", true);
        }

        if (isCharging && Input.GetMouseButton(0))
        {
            currentChargeTime += Time.deltaTime;
            float power = Mathf.Lerp(minShootForce, maxShootForce, currentChargeTime / chargeTime);
            power = Mathf.Clamp(power, minShootForce, maxShootForce);

            if (powerSlider != null) powerSlider.value = power;
        }

        if (Input.GetMouseButtonUp(0) && isCharging)
        {
            ShootProjectile();
            isCharging = false;

            // Hide slider
            if (powerSlider != null) powerSlider.gameObject.SetActive(false);

            // Stop charging animation and play shoot animation
            if (animator != null)
            {
                animator.SetBool("IsCharging", false);
                animator.SetTrigger("Shoot");
            }
        }
    }

    void FlipShootPoint()
    {
        if (playerSprite != null)
        {
            bool facingLeft = playerSprite.flipX;
            Vector3 shootPointPosition = shootPoint.localPosition;
            shootPointPosition.x = Mathf.Abs(shootPointPosition.x) * (facingLeft ? -1 : 1);
            shootPoint.localPosition = shootPointPosition;
        }
    }

    void ShootProjectile()
    {
        if (projectilePrefab != null && shootPoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float power = Mathf.Lerp(minShootForce, maxShootForce, currentChargeTime / chargeTime);
                power = Mathf.Clamp(power, minShootForce, maxShootForce);

                Vector2 shootDirection = (playerSprite.flipX ? Vector2.left : Vector2.right) + Vector2.up * 0.3f;
                shootDirection.Normalize();
                rb.AddForce(shootDirection * power, ForceMode2D.Impulse);
            }
        }
    }
}
