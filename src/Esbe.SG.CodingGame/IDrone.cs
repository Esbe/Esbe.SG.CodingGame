namespace Esbe.SG.CodingGame
{
    internal interface IDrone
    {
        /// <summary>
        ///     Moves the drone by one unit in the orientation it is facing, within the limits of the battlefield area.
        /// </summary>
        void Move();

        /// <summary>
        ///     Turns the drone right (clockwise) by 90 degrees.
        /// </summary>
        void TurnRight();

        /// <summary>
        ///     Turns the drone left (counter-clockwise) by 90 degrees.
        /// </summary>
        void TurnLeft();
    
        /// <summary>
        ///     Sets the battlefield area in which the object is allowed to exist.
        /// </summary>
        /// <param name="battlefieldArea">The battlefield area.</param>
        void SetBattlefieldArea(IBattlefieldArea battlefieldArea);

        /// <summary>
        ///     Determines whether the object is in battlefield area.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if is in battlefield area; otherwise, <c>false</c>.
        /// </returns>
        bool IsInBattlefieldArea();
    }
}