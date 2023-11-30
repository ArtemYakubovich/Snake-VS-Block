using System;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Snake))]
public class SnakeSizeUI : MonoBehaviour
{
   [SerializeField] private TMP_Text _view;

   [SerializeField] private Snake _snake;

   private void Awake()
   {
      OnSizeUpdated(_snake.GetSize());
   }

   private void OnEnable()
   {
      _snake.SizeUpdated += OnSizeUpdated;
   }

   private void OnDisable()
   {
      _snake.SizeUpdated -= OnSizeUpdated;
   }

   private void OnSizeUpdated(int size)
   {
      _view.text = size.ToString();
   }
}
