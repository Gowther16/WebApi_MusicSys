-- Insert dữ liệu Artists
INSERT INTO Artists (Name, Country, DateOfBirth, Biography)
VALUES
    (N'Sơn Tùng M-TP', N'Việt Nam', '1994-07-05', N'Nguyễn Thanh Tùng, được biết đến với nghệ danh Sơn Tùng M-TP, là một ca sĩ, nhạc sĩ, rapper và diễn viên người Việt Nam. Anh được coi là một trong những nghệ sĩ thành công và có tầm ảnh hưởng nhất trong ngành công nghiệp âm nhạc Việt Nam hiện nay.'),
    (N'Mỹ Tâm', N'Việt Nam', '1981-01-16', N'Phan Thị Mỹ Tâm, thường được biết đến với nghệ danh Mỹ Tâm, là một nữ ca sĩ, nhạc sĩ, diễn viên và nhà sản xuất âm nhạc người Việt Nam. Cô được người hâm mộ mệnh danh là "Nữ hoàng nhạc pop Việt Nam".'),
    (N'Đen Vâu', N'Việt Nam', '1989-05-13', N'Nguyễn Đức Cường, thường được biết đến với nghệ danh Đen Vâu hay Đen, là một nam rapper, nhạc sĩ nổi tiếng người Việt Nam. Anh nổi tiếng với những bài hát có ca từ ý nghĩa về cuộc sống, tình yêu và xã hội.'),
    (N'Hồ Ngọc Hà', N'Việt Nam', '1984-11-25', N'Hồ Ngọc Hà là một ca sĩ, diễn viên, người mẫu và doanh nhân người Việt Nam. Cô được biết đến với nhiều vai trò khác nhau trong làng giải trí Việt Nam và được coi là một trong những nghệ sĩ đa năng nhất.'),
    (N'Trúc Nhân', N'Việt Nam', '1991-04-29', N'Trúc Nhân là một ca sĩ người Việt Nam. Anh nổi tiếng sau khi tham gia chương trình Giọng hát Việt 2014 và được biết đến với giọng hát đặc biệt và phong cách biểu diễn sôi động.');

-- Insert dữ liệu Albums
INSERT INTO Albums (Title, Year, Producer, Description)
VALUES
    (N'Chúng Ta Của Hiện Tại', 2021, N'Sơn Tùng M-TP', N'Album solo của Sơn Tùng M-TP với các bản hit đình đám.'),
    (N'Tâm 9', 2017, N'Phương Nam Film', N'Album thứ 9 của Mỹ Tâm, đánh dấu sự trở lại mạnh mẽ của cô sau thời gian dài không ra album.'),
    (N'Lối Nhỏ', 2020, N'Đen Vâu', N'Album của rapper Đen Vâu với các ca khúc kết hợp cùng nhiều nghệ sĩ nổi tiếng.'),
    (N'Love Songs Collection', 2018, N'Hồ Ngọc Hà Entertainment', N'Album tuyển tập các ca khúc tình yêu nổi tiếng của Hồ Ngọc Hà qua các thời kỳ.'),
    (N'Thức Giấc', 2021, N'SpaceSpeakers', N'Album với ca khúc chủ đề "Thức Giấc" của Trúc Nhân, mang thông điệp tích cực về cuộc sống.');

-- Insert mối quan hệ Album-Artist (AlbumArtists)
INSERT INTO AlbumArtists (ArtistsArtistId, AlbumsAlbumId)
VALUES
    (1, 1), -- Sơn Tùng - Chúng Ta Của Hiện Tại
    (2, 2), -- Mỹ Tâm - Tâm 9
    (3, 3), -- Đen Vâu - Lối Nhỏ
    (4, 4), -- Hồ Ngọc Hà - Love Songs Collection
    (5, 5); -- Trúc Nhân - Thức Giấc

-- Insert dữ liệu Songs
INSERT INTO Songs (Title, Year, Genre, Duration, AlbumId, ArtistId)
VALUES
    -- Album Chúng Ta Của Hiện Tại (Sơn Tùng M-TP)
    (N'Chúng Ta Của Hiện Tại', 2021, N'Pop/Ballad', '00:04:37', 1, 1),
    (N'Muộn Rồi Mà Sao Còn', 2021, N'Pop/R&B', '00:04:35', 1, 1),
    
    -- Album Tâm 9 (Mỹ Tâm)
    (N'Đừng Hỏi Em', 2017, N'Pop/Ballad', '00:04:22', 2, 2),
    (N'Người Hãy Quên Em Đi', 2017, N'Pop', '00:04:18', 2, 2),
    
    -- Album Lối Nhỏ (Đen Vâu)
    (N'Lối Nhỏ', 2020, N'Rap/Acoustic', '00:04:53', 3, 3),
    (N'Trốn Tìm', 2020, N'Rap/Pop', '00:04:21', 3, 3),
    
    -- Album Love Songs Collection (Hồ Ngọc Hà)
    (N'Cả Một Trời Thương Nhớ', 2018, N'Ballad', '00:04:40', 4, 4),
    (N'Em Muốn Anh Đưa Em Về', 2018, N'Pop/R&B', '00:04:12', 4, 4),
    
    -- Album Thức Giấc (Trúc Nhân)
    (N'Thức Giấc', 2021, N'Pop', '00:03:55', 5, 5),
    (N'Sáng Mắt Chưa', 2021, N'Pop/Dance', '00:03:47', 5, 5);