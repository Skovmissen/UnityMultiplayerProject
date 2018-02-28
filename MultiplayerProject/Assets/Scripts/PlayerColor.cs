using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerColor : NetworkBehaviour
{

    // This list can be filled from the editor with multiple renderers in a prefab
    public List<SkinnedMeshRenderer> Meshes = new List<SkinnedMeshRenderer>();

    [SyncVar]
    public Color m_color;



    void Start()
    {
        if (isLocalPlayer)
        {

            foreach (SkinnedMeshRenderer mesh in Meshes)
            {
                mesh.material.color = m_color;
            }
            CmdSetMeshColors(m_color);
        }
        else
        {
            CmdSetMeshColors(m_color);
            foreach (SkinnedMeshRenderer mesh in Meshes)
            {
                mesh.material.color = m_color;
            }
        }

    }

    public override void OnStartClient()
    {

        if (isServer)
        {
            m_color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            RpcSetColor(m_color);
        }

    }




    [ClientRpc]
    void RpcSetColor(Color c)
    {
        m_color = c;
        foreach (SkinnedMeshRenderer mesh in Meshes)
        {
            mesh.material.color = m_color;
        }
    }


    //Server Commands
    [Command]
    public void CmdSetMeshColors(Color c)
    {
        m_color = c;
    }
}
	


