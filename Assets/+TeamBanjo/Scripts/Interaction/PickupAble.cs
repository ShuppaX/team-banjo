namespace TeamBanjo.Interaction
{
    public class PickupAble : PuzzleInteractable
    {
        public override void AfterInteractionAction()
        {
            base.AfterInteractionAction();
            gameObject.SetActive(false);
        }
    }
}
