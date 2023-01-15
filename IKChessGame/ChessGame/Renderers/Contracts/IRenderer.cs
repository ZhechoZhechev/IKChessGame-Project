
namespace ChessGame.Renderers.Contracts
{
    using ChessBoard.Contracts;
    public interface IRenderer
    {
        void RenderMainMenu();
        void RenderBoard(IBoard board);
    }
}
