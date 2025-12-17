using ScriptableObjects;
using Item;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerStatsController : MonoBehaviour
    {
        [Inject] PlayerStatsModel playerStatsModel;

        private List<ActiveBuff> buffs;
        public event Action BuffCountChanged;

        private void Start()
        {
            buffs = new List<ActiveBuff>();
        }

        public float MoveSpeed
        {
            get
            {
                return GetModifiedStat(EffectType.SPEED);
            }
        }

        public float Size
        {
            get
            {
                return GetModifiedStat(EffectType.SIZE);
            }
        }

        public float GetModifiedStat(EffectType statType)
        {
            float baseStat = 0f;
            switch (statType)
            {
                case EffectType.SPEED:
                    {
                        baseStat = playerStatsModel.MoveSpeed;
                        break;
                    }
                case EffectType.SIZE:
                    {
                        baseStat = playerStatsModel.Size;
                        break;
                    }
                default:
                    {
                        return baseStat;
                    }

            }
            foreach (ActiveBuff buff in buffs)
            {
                foreach (EffectConfig effect in buff.Config.Effects)
                {
                    if (effect.type == statType)
                    {
                        baseStat *= effect.multiplier;
                    }
                }
            }
            return baseStat;
        }

        public void AddBuff(ItemConfig buff)
        {
            ActiveBuff existingBuff;
            if (CheckForExistingBuff(buff.Id, out existingBuff))
            {
                existingBuff.Refresh();
            }
            else
            {
                buffs.Add(new ActiveBuff(buff, RemoveBuff));
                BuffCountChanged?.Invoke();
            }
        }

        private bool CheckForExistingBuff(string id, out ActiveBuff buff)
        {
            foreach (ActiveBuff item in buffs)
            {
                if (item.Config.Id == id)
                {
                    buff = item;
                    return true;
                }
            }
            buff = null;
            return false;
        }

        private void RemoveBuff(ActiveBuff buff)
        {
            buffs.Remove(buff);
            buff.Cancel();
            BuffCountChanged?.Invoke();
        }
    }
}