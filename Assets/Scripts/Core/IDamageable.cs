using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform2D.Core {

    /*
     * @author Deyvid Jaguaribe
     * @website https://deyvidjlira.com/
     * 
     * @created_at 28/12/2021
     * @last_update 28/12/2021
     * @description interface para personagens atingíveis
     * 
     */

    public interface IDamageable {

        void Damaged(int damage);

    }
}
