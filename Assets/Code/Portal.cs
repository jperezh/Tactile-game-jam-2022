using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Portal : MonoBehaviour
{
    enum PortalIndentifier
    {
        A, B, C, D
    }

    [SerializeField] PortalIndentifier portalIndentifier;
    [SerializeField] Transform spawnPosition;

    Portal[] allPortals;

    private void Start() {
        allPortals = FindObjectsOfType<Portal>();
        bool moreThen3 = allPortals.Select(p => p.portalIndentifier).GroupBy(n => n).Where(g => g.Count() > 2).Any();
        bool lessThen2 = allPortals.Select(p => p.portalIndentifier).GroupBy(n => n).Where(g => g.Count() < 2).Any();

        if (moreThen3) throw new Exception("There is more then 2 portals with the same PortalIndentifier");
        if (lessThen2) throw new Exception ("There is lonely portal");

    }

    Portal GetOtherPortal()
    {
        foreach (Portal otherPortal in FindObjectsOfType<Portal>())
        {
            if (otherPortal == this) continue;

            if (otherPortal.portalIndentifier == portalIndentifier) return otherPortal;
        }
        return null;
    }

    private void OnTriggerEnter2D(Collider2D player) {
        Portal otherPortal = GetOtherPortal();
        player.transform.position = otherPortal.spawnPosition.position;
    }
}
