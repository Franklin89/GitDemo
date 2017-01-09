# GitDemo

Git repository for demonstration

## Branching

The repository will be devided into 5 types of branches.

### Main branches: _master_ & _develop_
- The _master_ branch is where the source code always reflects a production-ready state
- The _develop_ branch is where the source code always reflects a state with the latest delivered development changes for the next release. Some would call this the “integration branch”.

### _feature_
- May branch off from: develop
- Must merge back into: develop
- Will use a pull request for code review
- Branch naming convention: anything except master, develop, release-*, or hotfix-*

Feature branches are used to develop new features or topics. At the time when starting the feature, the target release is unknown.

### _release_
- May branch off from: develop
- Must merge back into: develop and master
- Branch naming convention: release-*

Release branches are created from the develop branch. For example, version 1.1.5 is the current production release and we have a release coming up. The state of develop is ready for the “next release” and we decided that this will version 1.2 (rather than 1.1.6 or 2.0). So we branch off develop and give the release branch a name reflecting the new version number

### _hotfix_
- May branch off from: master
- Must merge back into: develop and master
- Will use a pull request for code review
- Branch naming convention: hotfix-*

Hotfix branches are very much like release branches in that they are also meant to prepare for a new production release. They arise from the necessity to act immediately upon an undesired state of a live production version. When a critical bug in a production version must be resolved immediately, a hotfix branch may be branched off from the corresponding tag on the master branch that marks the production version.

## Pull-Requests
Pull request is a feature that makes it easier for developers to collaborate. Pull request is a mechanism for a developer to notify team members that they have completed a feature.

Hint: Based on an article [Type of Pull Request](http://ben.balter.com/2015/12/08/types-of-pull-requests/), there are 6 types of PR. But WIP pattern is the one that is using by lots of teams and companies. It follows the mantra of “Open a Pull Request as early as possible”.