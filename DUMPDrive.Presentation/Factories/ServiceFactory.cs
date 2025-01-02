using DUMPDrive.Data.Repositories;
using DUMPDrive.Domain.Entities;
using DUMPDrive.Domain.Repositories;
using DUMPDrive.Domain.Services;

namespace DUMPDrive.Presentation.Factories
{
    public static class ServiceFactory
    {
        public static ServiceContainer CreateServices()
        {
            var users = new List<User>();
            var folders = new List<Folder>();
            var files = new List<FileItem>();
            var comments = new List<Comment>();

            var userRepository = new UserRepository(users);
            var folderRepository = new FolderRepository(folders);
            var fileRepository = new FileRepository(files);
            var commentRepository = new CommentRepository(comments);

            var userService = new UserService(userRepository);
            var folderService = new FolderService(folderRepository);
            var fileService = new FileService(fileRepository);
            var commentService = new CommentService(commentRepository);

            return new ServiceContainer
            {
                UserService = userService,
                FolderService = folderService,
                FileService = fileService,
                CommentService = commentService
            };
        }
    }

    public class ServiceContainer
    {
        public UserService UserService { get; set; }
        public FolderService FolderService { get; set; }
        public FileService FileService { get; set; }
        public CommentService CommentService { get; set; }
    }
}
