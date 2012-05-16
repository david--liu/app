def exit_if_on_the_master_branch
  exit_if_on_branch('master')
end

def exit_if_on_branch(branch)
  status = `git branch`

  if (%r/\* #{branch}/ =~ status)
    puts "You cant run this command on the branch #{branch}"
    exit
  end
end

def checkout(branch_name)
  `git checkout -b #{branch_name}`
  `git checkout #{branch_name}`
end

def exit_if_not_on_the_branch(branch)

  status = `git branch`

  if (%r/\* #{branch}/ !~ status)
    puts "You need to run this on the #{branch} branch"
    exit
  end

end
