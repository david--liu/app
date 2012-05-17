config = 
{
  :course_name => 'Developer Bootcamp',
  :project => "app",
  :target => "Debug",
  :source_dir =>"source",
  :web_staging_dir => "web_staging",
  :web_log_dir => delayed{File.join(configatron.web_staging_dir,'logs')},
  :web_trace_dir => delayed{File.join(configatron.web_staging_dir,'trace')},
  :all_references => UniqueFiles.new(Dir.glob("packages/**/*.{dll,exe}")).all_files,
  :artifacts_dir => "artifacts",
  :start_url => "http://localhost:8080/blah.austin",
  :config_dir => "source/config",
  :app_dir => delayed{"source/#{configatron.project}.web.ui"},
  :log_file_name => delayed{"#{configatron.project}_log.txt"},
  :log_level => "DEBUG"
}
configatron.configure_from_hash config
