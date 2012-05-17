require 'rake'
require 'rake/clean'
require 'fileutils'
require 'erb'
require 'configatron'

Dir.glob("build/support/**/*.rb").each do|item|
  require File.expand_path(item)
end

user_profile = "#{File.basename(`whoami`.chomp)}.settings"
unless File.exist?(user_profile)
  FileUtils.cp 'settings_template', user_profile
  p "You may need to change the settings in the file #{user_profile}"
end
load user_profile

config_files = FileList.new("source/config/*.erb")

[configatron.artifacts_dir, configatron.specs.dir].each do |item|
  CLEAN.include(item)
end

Rake::Task['expand_all_template_files'].invoke

task :default => ["specs:run"]

task :init  => :clean do
  [
    configatron.artifacts_dir,
    configatron.specs.dir,
    configatron.specs.report_dir,
    configatron.web_staging_dir,
    configatron.web_log_dir,
    configatron.web_trace_dir
  ].each do |folder| 
    FileUtils.mkdir_p folder if ! File.exists?(folder)
  end
end

task :copy_config_files do
  config_files.each do |file|
      [configatron.artifacts_dir,configatron.app_dir].each do|folder|
        FileUtils.cp(file.name_without_template_extension,
        folder.join(file.base_name_without_extension))
      end
  end
end

task :kill_iis do
  system("taskkill /IM iisexpress.exe")
end
