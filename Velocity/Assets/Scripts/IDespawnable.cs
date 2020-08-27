using System;
using UnityEngine;

/// <summary>
/// 디스폰 가능한 GameObject에 쓰이는 인터페이스 반환값 없는 이벤트 Action을 이용한 함수구현 
/// </summary>
public interface IDespawnable
{
    event Action<GameObject> OnDespawn;
}
