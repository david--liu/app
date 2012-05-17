require 'albacore'

namespace :build do
  desc 'compiles the project'
  csc :compile => :init do|csc| 
    csc.compile FileList["source/**/*.cs"].exclude("AssemblyInfo.cs")
    csc.references configatron.all_references
    csc.output = File.join(configatron.artifacts_dir,"#{configatron.project}.specs.dll")
    csc.target = :library
  end

  aspnetcompiler :web do |c|
    c.physical_path = "source/app.web.ui"
    c.target_path = configatron.web_staging_dir
    c.updateable = true
    c.force = true
  end

  task :rebuild => ["clean","compile"]

  task :run do
    system("start #{configatron.start_url}")
  end
end
