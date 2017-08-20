cd /d "c:\ffmpeg\hls\"
c:\ffmpeg\ffmpeg.exe -y -i rtsp://admin:pass.word1@192.168.137.183/ -c:v copy -c:a copy -f hls -hls_time 2 -hls_list_size 5 -use_localtime 1 -use_localtime_mkdir 1 -hls_segment_filename "cam-01-%%Y-%%m-%%d/cam-01-%%Y-%%m-%%d-%%H-%%M-%%S.ts" "cam-01.m3u8"
